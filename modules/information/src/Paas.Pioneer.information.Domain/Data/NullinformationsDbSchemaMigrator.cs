using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Information.Domain.Data
{
    /* This is used if database provider does't define
     * IInformationsDbSchemaMigrator implementation.
     */
    public class NullInformationsDbSchemaMigrator : IInformationsDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}