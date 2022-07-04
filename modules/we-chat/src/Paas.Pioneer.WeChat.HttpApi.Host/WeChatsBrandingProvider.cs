using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.WeChat.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class WeChatsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "WeChats";
    }
}
