using Volo.Abp.Settings;

namespace Paas.Pioneer.WeChat.Domain.Settings
{
    public class WeChatsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(WeChatsSettings.MySetting1));
        }
    }
}
