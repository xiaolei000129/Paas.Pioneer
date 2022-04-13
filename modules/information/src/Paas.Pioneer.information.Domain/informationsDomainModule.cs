using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Paas.Pioneer.information.Domain.Shared;
using Paas.Pioneer.information.Domain.Shared.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.information.Domain
{
    [DependsOn(
        typeof(informationsDomainSharedModule),
        typeof(AbpTenantManagementDomainModule)
    )]
    public class informationsDomainModule : AbpModule
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
