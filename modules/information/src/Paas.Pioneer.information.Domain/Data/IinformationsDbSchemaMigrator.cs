using System.Threading.Tasks;

namespace Paas.Pioneer.information.Domain.Data
{
    public interface IInformationsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
