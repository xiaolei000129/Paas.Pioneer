using Paas.Pioneer.Admin.Core.Application.Contracts;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.HttpApi
{
    [DependsOn(
        typeof(AdminsApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule)
        )]
    public class AdminsHttpApiModule : AbpModule
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
