using Volo.Abp.Settings;

namespace Paas.Pioneer.information.Domain.Settings
{
    public class informationsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(informationsSettings.MySetting1));
        }
    }
}
