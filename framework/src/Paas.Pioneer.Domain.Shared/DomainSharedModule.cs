using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Domain.Shared.ApplicationBuilderExtensions;
using Paas.Pioneer.Domain.Shared.Configs;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Paas.Pioneer
{
	[DependsOn()]
	public class DomainSharedModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			var configuration = context.Services.GetConfiguration();

			context.Services.Configure<AppConfig>(configuration.GetSection("appconfig"));

			context.Services.Configure<JwtConfig>(configuration.GetSection("jwtconfig"));

			context.Services.Configure<UploadConfig>(configuration.GetSection("uploadconfig"));
		}

		public override void OnApplicationInitialization(ApplicationInitializationContext context)
		{
			var app = context.GetApplicationBuilder();
			var env = context.GetEnvironment();

			// 静态资源文件拓展
			app.UseUploadConfig();
		}
	}
}
