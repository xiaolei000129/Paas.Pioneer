using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Role
{
    public interface IRoleService : IApplicationService
    {
        Task<ResponseOutput<RoleGetOutput>> GetAsync(Guid id);

        Task<ResponseOutput<Page<RoleListOutput>>> GetPageListAsync(PageInput<RoleInput> input);

        Task<IResponseOutput> AddAsync(RoleAddInput input);

        Task<IResponseOutput> UpdateAsync(RoleUpdateInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> BatchSoftDeleteAsync(Guid[] ids);
    }
}