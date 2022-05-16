using Paas.Pioneer.Workflow.Application;
using Paas.Pioneer.Workflow.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Workflow.Application.Tests
{
    [DependsOn(
        typeof(WorkflowsApplicationModule),
        typeof(WorkflowsDomainTestModule)
        )]
    public class WorkflowsApplicationTestModule : AbpModule
    {

    }
}