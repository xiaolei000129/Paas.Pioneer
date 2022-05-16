using System.Threading.Tasks;

namespace Paas.Pioneer.Workflow.Domain.Data
{
    public interface IWorkflowsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
