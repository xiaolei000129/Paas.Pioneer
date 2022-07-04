using Paas.Pioneer.WeChat.Domain.WeChatApps;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.WeChat.Domain.MiniPrograms
{
    public class MiniProgramLoginProviderProvider : IMiniProgramLoginProviderProvider, ITransientDependency
    {
        public virtual string WeChatAppLoginProviderPrefix { get; } = "WeChatApp:";
        public virtual string WeChatOpenLoginProviderPrefix { get; } = "WeChatOpen:";

        public virtual Task<string> GetAppLoginProviderAsync(WeChatApp miniProgram)
        {
            Check.NotNullOrWhiteSpace(miniProgram.AppId, nameof(miniProgram.AppId));

            return Task.FromResult(WeChatAppLoginProviderPrefix + miniProgram.AppId);
        }

        public virtual Task<string> GetOpenLoginProviderAsync(WeChatApp miniProgram)
        {
            Check.NotNullOrWhiteSpace(miniProgram.OpenAppIdOrName, nameof(miniProgram.OpenAppIdOrName));

            return Task.FromResult(WeChatOpenLoginProviderPrefix + miniProgram.OpenAppIdOrName);
        }
    }
}