using Paas.Pioneer.Admin.Core.Domain.Shared;
using Paas.Pioneer.Redis;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Admin.Core.Application.Contracts
{
    [DependsOn(
        typeof(AdminsDomainSharedModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule),
        typeof(RedisModule)
    )]
    public class AdminsApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AdminsDtoExtensions.Configure();
        }
    }
}
