using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace ZhouCaiFramework.Common
{
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Add SqlSugar database to DI container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlSugarDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISqlSugarClient>(provider =>
            {
                var connectionString = configuration.GetConnectionString("MySqlConnection");
                return new SqlSugarScope(new ConnectionConfig()
                {
                    ConnectionString = connectionString,
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true
                },
                db =>
                {
                    // Configure AOP
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        // Log SQL before execution
                    };
                });
            });

            return services;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Backup"></param>
        /// <param name="StringDefaultLength"></param>
        /// <param name="types"></param>
        public static void InitDatabase(this ISqlSugarClient db, bool Backup = false, int StringDefaultLength = 255, params Type[] types)
        {
            foreach (var i in types)
            {
                Console.WriteLine("创建表" + i.Name);
            }

            try
            {
                db.CodeFirst.SetStringDefaultLength(StringDefaultLength);
                db.DbMaintenance.CreateDatabase();
                if (Backup)
                {
                    db.CodeFirst.BackupTable().InitTables(types);
                }
                else
                {
                    db.CodeFirst.InitTables(types);
                }
                // 关闭连接
                db.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}