using Paas.Pioneer.Workflow.Application.Contracts;
using Paas.Pioneer.Workflow.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.Workflow.Application
{
    [DependsOn(
        typeof(WorkflowsDomainModule),
        typeof(WorkflowsApplicationContractsModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class WorkflowsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<WorkflowsApplicationModule>();
            });
        }
    }
}
