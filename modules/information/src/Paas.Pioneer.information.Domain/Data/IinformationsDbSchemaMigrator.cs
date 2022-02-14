using System.Threading.Tasks;

namespace Paas.Pioneer.Information.Domain.Data
{
    public interface IInformationsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
