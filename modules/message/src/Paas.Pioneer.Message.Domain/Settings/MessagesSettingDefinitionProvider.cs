using Volo.Abp.Settings;

namespace Paas.Pioneer.Message.Domain.Settings
{
    public class MessagesSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MessagesSettings.MySetting1));
        }
    }
}
