using Paas.Pioneer.Workflow.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Workflow.Application.Contracts
{
    [DependsOn(
        typeof(WorkflowsDomainSharedModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
        )]
    public class WorkflowsApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            WorkflowsDtoExtensions.Configure();
        }
    }
}
