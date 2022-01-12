using System.Threading.Tasks;

namespace Paas.Pioneer.Template.Domain.Data
{
    public interface ITemplatesDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
