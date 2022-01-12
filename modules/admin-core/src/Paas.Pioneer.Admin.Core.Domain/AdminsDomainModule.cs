using Paas.Pioneer.Admin.Core.Domain.Shared;
using Paas.Pioneer.Admin.Core.Domain.Shared.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Domain
{
    [DependsOn(
        typeof(AdminsDomainSharedModule),
        typeof(AbpTenantManagementDomainModule)
    )]
    public class AdminsDomainModule : AbpModule
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
