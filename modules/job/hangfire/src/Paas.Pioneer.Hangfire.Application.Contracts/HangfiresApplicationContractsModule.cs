using Paas.Pioneer.Admin.Core.Application.Contracts;
using Paas.Pioneer.Hangfire.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Hangfire.Application.Contracts
{
    [DependsOn(
        typeof(HangfiresDomainSharedModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule),
        typeof(AdminsApplicationContractsModule)
    )]
    public class HangfiresApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HangfiresDtoExtensions.Configure();
        }
    }
}
