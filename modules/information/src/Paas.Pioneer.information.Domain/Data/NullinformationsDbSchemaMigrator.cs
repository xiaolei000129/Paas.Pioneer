using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.information.Domain.Data
{
    /* This is used if database provider does't define
     * IinformationsDbSchemaMigrator implementation.
     */
    public class NullinformationsDbSchemaMigrator : IinformationsDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}