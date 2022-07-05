using System;
using System.Threading.Tasks;
using Paas.Pioneer.User.Application.Contracts.UserInfos.Dtos;
using Paas.Pioneer.User.Domain.Shared.UserInfos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.User.Application.Contracts.UserInfos
{
    public interface IUserInfoAppService :
        IReadOnlyAppService<
            UserInfoDto,
            Guid,
            PagedAndSortedResultRequestDto>
    {
        Task<UserInfoDto> UpdateAsync(UserInfoModel input);
    }
}