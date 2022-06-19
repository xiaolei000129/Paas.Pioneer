using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Message.Domain.Data
{
    /* This is used if database provider does't define
     * IMessagesDbSchemaMigrator implementation.
     */
    public class NullMessagesDbSchemaMigrator : IMessagesDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}