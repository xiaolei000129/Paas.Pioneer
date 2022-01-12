using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Admin.Core.Domain.Data
{
    /* This is used if database provider does't define
     * IAdminsDbSchemaMigrator implementation.
     */
    public class NullAdminsDbSchemaMigrator : IAdminsDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}