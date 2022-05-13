using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Paas.Pioneer.Information.Domain.Shared;
using Paas.Pioneer.Information.Domain.Shared.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Information.Domain
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
