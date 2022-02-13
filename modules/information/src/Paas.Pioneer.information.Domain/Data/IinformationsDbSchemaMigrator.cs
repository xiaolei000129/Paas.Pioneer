using System.Threading.Tasks;

namespace Paas.Pioneer.information.Domain.Data
{
    public interface IinformationsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
