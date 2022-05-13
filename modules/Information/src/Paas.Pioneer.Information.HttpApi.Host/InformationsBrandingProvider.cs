using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.Information.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class InformationsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Informations";
    }
}
