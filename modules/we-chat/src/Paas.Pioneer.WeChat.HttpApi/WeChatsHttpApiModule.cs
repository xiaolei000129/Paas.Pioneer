using Paas.Pioneer.WeChat.Application.Contracts;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.WeChat.HttpApi
{
    [DependsOn(
        typeof(WeChatsApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule)
        )]
    public class WeChatsHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {

            });
        }
    }
}
