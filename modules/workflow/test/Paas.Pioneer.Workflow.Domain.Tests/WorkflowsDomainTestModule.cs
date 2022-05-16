using Paas.Pioneer.Workflow.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Workflow.Domain.Tests
{
    [DependsOn(
        typeof(WorkflowsEntityFrameworkCoreTestModule)
        )]
    public class WorkflowsDomainTestModule : AbpModule
    {

    }
}