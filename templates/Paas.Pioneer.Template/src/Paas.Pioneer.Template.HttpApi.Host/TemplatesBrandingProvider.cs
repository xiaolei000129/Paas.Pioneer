using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.Template.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class TemplatesBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Templates";
    }
}
