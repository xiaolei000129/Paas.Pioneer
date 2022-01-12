using Volo.Abp.Settings;

namespace Paas.Pioneer.Template.Domain.Settings
{
    public class TemplatesSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TemplatesSettings.MySetting1));
        }
    }
}
