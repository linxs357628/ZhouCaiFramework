using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using SqlSugar;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Services;
using ZhouCaiFramework.Web.Validators;

namespace ZhouCaiFramework.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register services from ZhouCaiFramework.Services.dll
            var assembly = Assembly.LoadFrom("ZhouCaiFramework.Services.dll".GetDirectoryCombine());
            builder.RegisterAssemblyTypes(assembly)
                //.Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("front", new() { Title = "ZhouCai Front API", Version = "v1" });
                c.SwaggerDoc("admin", new() { Title = "ZhouCai Admin API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                var xmlFile2 = $"ZhouCaiFramework.Model.xml";
                var xmlPath2 = Path.Combine(AppContext.BaseDirectory, xmlFile2);
                c.IncludeXmlComments(xmlPath2, includeControllerXmlComments: true);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, Array.Empty<string>()}
                });

                c.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out var methodInfo))
                        return false;

                    var routeTemplate = "/" + methodInfo.DeclaringType.GetCustomAttributes(true)
                               .OfType<RouteAttribute>()
                               .Select(attr => attr.Template.TrimStart('/'))
                               .FirstOrDefault();

                    if (routeTemplate.StartsWith("/api/admin"))
                        return version == "admin";
                    else if (routeTemplate.StartsWith("/api/front/"))
                        return version == "front";
                    else
                        return false;
                });
            });

            // 注册 FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            services.AddSqlSugarDatabase(Configuration);
            services.AddRedisCache(Configuration);
            services.AddJwtAuthentication(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/front/swagger.json", "ZhouCai Front API v1");
                    c.SwaggerEndpoint("/swagger/admin/swagger.json", "ZhouCai Admin API v1");
                    c.DefaultModelsExpandDepth(-1);
                    c.EnablePersistAuthorization();
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // 认证中间件
            app.UseAuthentication();

            // 授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}