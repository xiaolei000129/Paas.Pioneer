using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.information.Application.Contracts.Permissions
{
    public class informationsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(informationsPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(informationsPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
