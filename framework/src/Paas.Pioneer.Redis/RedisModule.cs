using CSRedis;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Redis
{
	[DependsOn()]
	public class RedisModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			var configuration = context.Services.GetConfiguration();
			var csredis = new CSRedisClient(configuration["ConnectionStrings:Redis"]);
			RedisHelper.Initialization(csredis);
			context.Services.AddMemoryCache();
		}
	}
}
