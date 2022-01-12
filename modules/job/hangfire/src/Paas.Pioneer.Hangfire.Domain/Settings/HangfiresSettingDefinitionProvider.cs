using Volo.Abp.Settings;

namespace Paas.Pioneer.Hangfire.Domain.Settings
{
    public class HangfiresSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HangfiresSettings.MySetting1));
        }
    }
}
