using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Permissions
{
    public class AdminsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AdminsPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AdminsPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
