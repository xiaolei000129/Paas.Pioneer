using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.Admin.Core.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class AdminsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Admins";
    }
}
