using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Paas.Pioneer.Workflow.HttpApi.Host
{
    [Dependency(ReplaceServices = true)]
    public class WorkflowsBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Workflows";
    }
}
