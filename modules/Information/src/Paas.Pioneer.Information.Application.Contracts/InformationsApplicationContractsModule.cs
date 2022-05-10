using Paas.Pioneer.Information.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Information.Application.Contracts
{
    [DependsOn(
        typeof(InformationsDomainSharedModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
        )]
    public class InformationsApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            InformationsDtoExtensions.Configure();
        }
    }
}
