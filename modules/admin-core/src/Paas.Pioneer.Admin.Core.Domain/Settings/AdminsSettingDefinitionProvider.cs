using Volo.Abp.Settings;

namespace Paas.Pioneer.Admin.Core.Domain.Settings
{
    public class AdminsSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AdminsSettings.MySetting1));
        }
    }
}
