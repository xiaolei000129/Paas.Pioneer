using Paas.Pioneer.information.Domain.Shared;
using Paas.Pioneer.information.Domain.Shared.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.information.Domain
{
    [DependsOn(
        typeof(InformationsDomainSharedModule),
        typeof(AbpTenantManagementDomainModule)
    )]
    public class InformationsDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }
    }
}
