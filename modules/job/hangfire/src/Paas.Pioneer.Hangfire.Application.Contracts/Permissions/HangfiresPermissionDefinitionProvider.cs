using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.Hangfire.Application.Contracts.Permissions
{
    public class HangfiresPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HangfiresPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(HangfiresPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
