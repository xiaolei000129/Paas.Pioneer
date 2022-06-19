using System.Threading.Tasks;

namespace Paas.Pioneer.Message.Domain.Data
{
    public interface IMessagesDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
