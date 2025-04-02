using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace ZhouCaiFramework.Common
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnection = configuration.GetConnectionString("RedisConnection");
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));
            services.AddScoped<IDatabase>(provider =>
            {
                var redis = provider.GetRequiredService<IConnectionMultiplexer>();
                return redis.GetDatabase();
            });

            return services;
        }
    }
}