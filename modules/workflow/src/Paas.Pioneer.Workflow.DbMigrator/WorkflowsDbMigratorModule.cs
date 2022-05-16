using Paas.Pioneer.Workflow.Application.Contracts;
using Paas.Pioneer.Workflow.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Workflow.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(WorkflowsEntityFrameworkCoreModule),
        typeof(WorkflowsApplicationContractsModule)
        )]
    public class WorkflowsDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}
