using Paas.Pioneer.information.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.information.Application.Contracts
{
    [DependsOn(
        typeof(informationsDomainSharedModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
        )]
    public class informationsApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            informationsDtoExtensions.Configure();
        }
    }
}
