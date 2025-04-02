using Autofac;
using Autofac.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    //// Check for required DLL
    //var servicesDllFile = "ZhouCaiFramework.Services.dll".GetDirectoryCombine();
    //if (!File.Exists(servicesDllFile))
    //{
    //    throw new Exception("dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。");
    //}

    // NLog setup
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Use Autofac for DI
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    // Use Startup class
    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services);

    // Configure Autofac container
    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
        startup.ConfigureContainer(builder);
    });

    var app = builder.Build();
    startup.Configure(app, app.Environment);

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
