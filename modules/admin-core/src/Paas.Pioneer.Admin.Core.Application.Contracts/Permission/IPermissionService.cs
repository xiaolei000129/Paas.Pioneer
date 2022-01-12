using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Permission.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Permission
{
    public interface IPermissionService : IApplicationService
    {
        Task<ResponseOutput<PermissionGetGroupOutput>> GetGroupAsync(Guid id);

        Task<ResponseOutput<PermissionGetMenuOutput>> GetMenuAsync(Guid id);

        Task<ResponseOutput<PermissionGetApiOutput>> GetApiAsync(Guid id);

        Task<ResponseOutput<PermissionGetDotOutput>> GetDotAsync(Guid id);

        Task<IResponseOutput> GetPermissionListAsync();

        Task<ResponseOutput<List<Guid>>> GetRolePermissionListAsync(Guid roleId);

        Task<ResponseOutput<IEnumerable<Guid>>> GetTenantPermissionListAsync(Guid tenantId);

        Task<ResponseOutput<List<PermissionListOutput>>> GetListAsync(string key, DateTime? start, DateTime? end);

        Task<IResponseOutput> AddGroupAsync(PermissionAddGroupInput input);

        Task<IResponseOutput> AddMenuAsync(PermissionAddMenuInput input);

        Task<IResponseOutput> AddApiAsync(PermissionAddApiInput input);

        Task<IResponseOutput> AddDotAsync(PermissionAddDotInput input);

        Task<IResponseOutput> UpdateGroupAsync(PermissionUpdateGroupInput input);

        Task<IResponseOutput> UpdateMenuAsync(PermissionUpdateMenuInput input);

        Task<IResponseOutput> UpdateApiAsync(PermissionUpdateApiInput input);

        Task<IResponseOutput> UpdateDotAsync(PermissionUpdateDotInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> AssignAsync(PermissionAssignInput input);

        Task<IResponseOutput> SaveTenantPermissionsAsync(PermissionSaveTenantPermissionsInput input);

    }
}