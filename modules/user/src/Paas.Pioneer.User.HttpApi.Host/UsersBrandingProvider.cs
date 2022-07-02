using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.User.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class UsersBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Users";
    }
}
