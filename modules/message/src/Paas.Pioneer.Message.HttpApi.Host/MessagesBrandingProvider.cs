using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.Message.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class MessagesBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Messages";
    }
}
