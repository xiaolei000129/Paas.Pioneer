using EasyCaching.CSRedis;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Redis
{
    [DependsOn()]
    public class RedisModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddEasyCaching(x =>
                x.UseCSRedis(options =>
                {
                    options.DBConfig = new CSRedisDBOptions
                    {
                        ConnectionStrings = new List<string>
                        {
                            configuration["ConnectionStrings:Redis"]
                        }
                    };
                }).UseCSRedisLock());
        }
    }
}
