using Paas.Pioneer.WeChat.Domain.WeChatApps;
using System.Threading.Tasks;

namespace Paas.Pioneer.WeChat.Domain.MiniPrograms
{
    public interface IMiniProgramLoginProviderProvider
    {
        string WeChatAppLoginProviderPrefix { get; }
        string WeChatOpenLoginProviderPrefix { get; }

        Task<string> GetAppLoginProviderAsync(WeChatApp miniProgram);

        Task<string> GetOpenLoginProviderAsync(WeChatApp miniProgram);
    }
}