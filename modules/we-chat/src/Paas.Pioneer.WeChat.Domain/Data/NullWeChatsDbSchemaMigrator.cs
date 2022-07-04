using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.WeChat.Domain.Data
{
    /* This is used if database provider does't define
     * IWeChatsDbSchemaMigrator implementation.
     */
    public class NullWeChatsDbSchemaMigrator : IWeChatsDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}