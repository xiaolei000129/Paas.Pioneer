using Paas.Pioneer.User.Domain.Shared;
using Paas.Pioneer.User.Domain.Shared.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.User.Domain;

[DependsOn(
    typeof(UsersDomainSharedModule),
    typeof(AbpTenantManagementDomainModule)
)]
public class UsersDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });
    }
}
