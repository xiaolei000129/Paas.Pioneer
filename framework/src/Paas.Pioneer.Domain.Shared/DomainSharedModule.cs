using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Paas.Pioneer.Domain.Shared;
using Paas.Pioneer.Domain.Shared.ApplicationBuilderExtensions;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.Domain.Shared.Extensions;
using Paas.Pioneer.Domain.Shared.Provider;
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

            context.Services.AddControllers(options =>
            {
                //options.Filters.Add<ModelValidAttribute>(-1);
                //options.Filters.Add<ResultWrapperFilter>();
            });
            context.Services.Replace(ServiceDescriptor.Singleton<IApplicationModelProvider, ResultWrapperApplicationModelProvider>());
            context.Services.AddEndpointsApiExplorer();
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
