using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.User.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.User
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService : IApplicationService
    {
        Task<ResponseOutput<AuthLoginOutput>> GetLoginUserAsync(Guid id);

        Task<ResponseOutput<UserAndRoleOutput>> GetAsync(Guid id);

        Task<ResponseOutput<SelectModel>> GetSelectAsync();

        Task<ResponseOutput<Page<GetUserPageListOutput>>> GetPageListAsync(PageInput<UserModelInput> input);

        Task<IResponseOutput> AddAsync(UserAddInput input);

        Task<IResponseOutput> UpdateAsync(UserUpdateInput input);

        Task<IResponseOutput> DeleteAsync(Guid id);

        Task<IResponseOutput> BatchSoftDeleteAsync(Guid[] ids);

        Task<IResponseOutput> ChangePasswordAsync(UserChangePasswordInput input);

        Task<IResponseOutput> UpdateBasicAsync(UserUpdateBasicInput input);

        Task<ResponseOutput<UserModelOutput>> GetBasicAsync();

        // Task<IList<UserPermissionsOutput>> GetPermissionsAsync();
    }
}