using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Hangfire.Domain.Data
{
    /* This is used if database provider does't define
     * IHangfiresDbSchemaMigrator implementation.
     */
    public class NullHangfiresDbSchemaMigrator : IHangfiresDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}