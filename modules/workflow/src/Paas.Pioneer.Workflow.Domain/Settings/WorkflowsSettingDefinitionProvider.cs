using Volo.Abp.Settings;

namespace Paas.Pioneer.Workflow.Domain.Settings
{
    public class WorkflowsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(WorkflowsSettings.MySetting1));
        }
    }
}
