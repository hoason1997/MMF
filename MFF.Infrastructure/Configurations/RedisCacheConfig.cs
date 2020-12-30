using MFF.DTO.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MFF.Infrastructure.Configurations
{
    public static class RedisCacheConfig
    {
        public static void AddRedisCacheConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheOptions = new RedisCacheSetting();
            configuration.GetSection("RedisCacheSetting").Bind(redisCacheOptions);
            if (redisCacheOptions == null)
                throw new Exception("Could not found redis cache settings");

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = redisCacheOptions.Configuration;
                option.InstanceName = redisCacheOptions.InstanceName;
            });
        }
    }
}
