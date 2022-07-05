using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.User.Application.Contracts.Permissions;

public class UsersPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UsersPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(UsersPermissions.MyPermission1, L("Permission:MyPermission1"));
    }
}
