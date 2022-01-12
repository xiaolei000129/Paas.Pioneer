using System.Threading.Tasks;

namespace Paas.Pioneer.Hangfire.Domain.Data
{
    public interface IHangfiresDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
