using System;
using System.Threading.Tasks;
using Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.UserInfos.Dtos;
using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms.UserInfos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.UserInfos
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