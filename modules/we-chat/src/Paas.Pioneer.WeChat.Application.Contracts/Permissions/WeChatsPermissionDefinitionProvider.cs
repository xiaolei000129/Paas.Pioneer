using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.WeChat.Application.Contracts.Permissions
{
    public class WeChatsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(WeChatsPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(WeChatsPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
