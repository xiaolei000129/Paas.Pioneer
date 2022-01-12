using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Data
{
    public interface IAdminsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
