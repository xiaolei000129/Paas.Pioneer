using System;
using System.Threading.Tasks;
using EasyAbp.WeChatManagement.MiniPrograms.Permissions;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.User.Application.Contracts.UserInfos;
using Paas.Pioneer.User.Application.Contracts.UserInfos.Dtos;
using Paas.Pioneer.User.Domain.Shared.UserInfos;
using Paas.Pioneer.User.Domain.UserInfos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Paas.Pioneer.User.Application.UserInfos
{
    public class UserInfoAppService : ReadOnlyAppService<UserInfo, UserInfoDto, Guid, PagedAndSortedResultRequestDto>,
        IUserInfoAppService
    {
        protected override string GetPolicyName { get; set; } = MiniProgramsPermissions.UserInfo.Default;
        protected override string GetListPolicyName { get; set; } = MiniProgramsPermissions.UserInfo.Default;

        private readonly IUserInfoRepository _repository;

        public UserInfoAppService(IUserInfoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [Authorize]
        public async Task<UserInfoDto> UpdateAsync(UserInfoModel input)
        {
            var userInfo = await _repository.FindAsync(x => x.UserId == CurrentUser.GetId());

            userInfo.UpdateInfo(input);

            await _repository.UpdateAsync(userInfo, true);

            return await MapToGetOutputDtoAsync(userInfo);
        }
    }
}