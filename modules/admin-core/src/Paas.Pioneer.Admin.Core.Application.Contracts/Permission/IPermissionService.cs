using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Output;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Permission
{
    public interface IPermissionService : IApplicationService
    {
        Task<PermissionGetGroupOutput> GetGroupAsync(Guid id);

        Task<PermissionGetMenuOutput> GetMenuAsync(Guid id);

        Task<PermissionGetApiOutput> GetApiAsync(Guid id);

        Task<PermissionGetDotOutput> GetDotAsync(Guid id);

        Task<object> GetPermissionListAsync();

        Task<List<Guid>> GetRolePermissionListAsync(Guid roleId);

        Task<IEnumerable<Guid>> GetTenantPermissionListAsync(Guid tenantId);

        Task<List<PermissionListOutput>> GetListAsync(string key, DateTime? start, DateTime? end);

        Task AddGroupAsync(PermissionAddGroupInput input);

        Task AddMenuAsync(PermissionAddMenuInput input);

        Task AddApiAsync(PermissionAddApiInput input);

        Task AddDotAsync(PermissionAddDotInput input);

        Task UpdateGroupAsync(PermissionUpdateGroupInput input);

        Task UpdateMenuAsync(PermissionUpdateMenuInput input);

        Task UpdateApiAsync(PermissionUpdateApiInput input);

        Task UpdateDotAsync(PermissionUpdateDotInput input);

        Task DeleteAsync(Guid id);

        Task AssignAsync(PermissionAssignInput input);

        Task SaveTenantPermissionsAsync(PermissionSaveTenantPermissionsInput input);

    }
}