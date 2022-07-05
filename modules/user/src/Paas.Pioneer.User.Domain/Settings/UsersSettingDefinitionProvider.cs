using Volo.Abp.Settings;

namespace Paas.Pioneer.User.Domain.Settings;

public class UsersSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(UsersSettings.MySetting1));
    }
}
