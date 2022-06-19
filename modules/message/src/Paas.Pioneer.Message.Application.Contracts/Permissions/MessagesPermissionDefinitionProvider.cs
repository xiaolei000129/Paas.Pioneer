using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.Message.Application.Contracts.Permissions
{
    public class MessagesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MessagesPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(MessagesPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
