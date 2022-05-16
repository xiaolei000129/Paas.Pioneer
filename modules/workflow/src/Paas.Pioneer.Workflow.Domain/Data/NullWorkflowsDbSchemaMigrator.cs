using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Workflow.Domain.Data
{
    /* This is used if database provider does't define
     * IWorkflowsDbSchemaMigrator implementation.
     */
    public class NullWorkflowsDbSchemaMigrator : IWorkflowsDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}