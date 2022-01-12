using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.Hangfire.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class HangfiresBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Hangfires";
    }
}
