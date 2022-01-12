using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Knife4jUI.Swagger;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Paas.Pioneer
{
	[DependsOn()]
	public class Knife4jUISwaggerModule : AbpModule
	{
		private const string ApplicationName = "Paas.Pioneer";
		public override void ConfigureServices(ServiceConfigurationContext context)
{
			//添加Swagger接口文档描述
			context.Services.AddSwaggerGen(ApplicationName, ApplicationName);
		}

		public override void OnApplicationInitialization(ApplicationInitializationContext context)
		{
			var app = context.GetApplicationBuilder();
			app.UseSwaggerUI("/v1/api-docs", ApplicationName);
		}
	}
}
