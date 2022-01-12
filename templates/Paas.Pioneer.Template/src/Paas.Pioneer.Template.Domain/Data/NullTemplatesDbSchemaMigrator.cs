using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Template.Domain.Data
{
    /* This is used if database provider does't define
     * ITemplatesDbSchemaMigrator implementation.
     */
    public class NullTemplatesDbSchemaMigrator : ITemplatesDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}