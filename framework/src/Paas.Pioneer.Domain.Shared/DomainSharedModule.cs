using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.ApplicationBuilderExtensions;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.Domain.Shared.Filter;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Domain.Shared
{
    [DependsOn(
        typeof(AutoWrapperModule)
    )]
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
                options.Filters.Add<ModelValidAttribute>(-1);
            });
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
