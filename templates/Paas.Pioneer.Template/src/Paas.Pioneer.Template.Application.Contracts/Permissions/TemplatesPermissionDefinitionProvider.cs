using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.Template.Application.Contracts.Permissions
{
    public class TemplatesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TemplatesPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(TemplatesPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
