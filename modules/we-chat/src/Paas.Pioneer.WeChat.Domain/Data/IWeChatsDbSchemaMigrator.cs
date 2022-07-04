using System.Threading.Tasks;

namespace Paas.Pioneer.WeChat.Domain.Data
{
    public interface IWeChatsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
