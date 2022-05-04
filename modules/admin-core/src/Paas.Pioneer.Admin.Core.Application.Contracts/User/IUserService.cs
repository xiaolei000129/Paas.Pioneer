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
        Task<AuthLoginOutput> GetLoginUserAsync(Guid id);

        Task<UserAndRoleOutput> GetAsync(Guid id);

        Task<SelectModel> GetSelectAsync();

        Task<Page<GetUserPageListOutput>> GetPageListAsync(PageInput<UserModelInput> input);

        Task AddAsync(UserAddInput input);

        Task UpdateAsync(UserUpdateInput input);

        Task DeleteAsync(Guid id);

        Task BatchSoftDeleteAsync(Guid[] ids);

        Task ChangePasswordAsync(UserChangePasswordInput input);

        Task UpdateBasicAsync(UserUpdateBasicInput input);

        Task<UserModelOutput> GetBasicAsync();

        // Task<IList<UserPermissionsOutput>> GetPermissionsAsync();
    }
}