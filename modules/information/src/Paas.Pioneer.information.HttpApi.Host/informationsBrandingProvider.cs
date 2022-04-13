using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.information.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class informationsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "informations";
    }
}
