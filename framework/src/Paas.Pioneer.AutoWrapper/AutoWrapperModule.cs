using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.AutoWrapper
{
    [DependsOn()]
    public class AutoWrapperModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // Method intentionally left empty.
            context.Services.AddSingleton(typeof(IResponseOutput<>), typeof(ResponseOutput<>));
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            // Method intentionally left empty.
        }
    }
}
