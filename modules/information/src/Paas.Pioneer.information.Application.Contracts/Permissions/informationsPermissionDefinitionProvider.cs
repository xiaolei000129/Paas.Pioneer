using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.Information.Application.Contracts.Permissions
{
    public class InformationsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(InformationsPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(InformationsPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
