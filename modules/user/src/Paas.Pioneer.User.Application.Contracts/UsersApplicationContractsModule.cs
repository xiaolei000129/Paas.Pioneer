using Paas.Pioneer.User.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.User.Application.Contracts
{
    [DependsOn(
        typeof(UsersDomainSharedModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
        )]
    public class UsersApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            UsersDtoExtensions.Configure();
        }
    }
}
