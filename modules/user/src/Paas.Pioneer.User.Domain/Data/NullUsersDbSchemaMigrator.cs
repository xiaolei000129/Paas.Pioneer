using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.User.Domain.Data
{
    /* This is used if database provider does't define
     * IUsersDbSchemaMigrator implementation.
     */
    public class NullUsersDbSchemaMigrator : IUsersDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}