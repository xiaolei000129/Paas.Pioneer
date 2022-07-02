using System.Threading.Tasks;

namespace Paas.Pioneer.User.Domain.Data
{
    public interface IUsersDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
