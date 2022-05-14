using Volo.Abp.Settings;

namespace Paas.Pioneer.Information.Domain.Settings
{
    public class InformationsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(InformationsSettings.MySetting1));
        }
    }
}
