using Volo.Abp.Authorization.Permissions;

namespace Paas.Pioneer.Workflow.Application.Contracts.Permissions
{
    public class WorkflowsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(WorkflowsPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(WorkflowsPermissions.MyPermission1, L("Permission:MyPermission1"));
        }
    }
}
