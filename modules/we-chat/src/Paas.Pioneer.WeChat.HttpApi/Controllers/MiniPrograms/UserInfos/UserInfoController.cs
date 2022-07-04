using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.UserInfos;
using Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.UserInfos.Dtos;
using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms.UserInfos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Paas.Pioneer.WeChat.HttpApi.Controllers.MiniPrograms.UserInfos
{
    [Route("/api/wechat-management/mini-programs/user-info")]
    public class UserInfoController : MiniProgramsController, IUserInfoAppService
    {
        private readonly IUserInfoAppService _service;

        public UserInfoController(IUserInfoAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<UserInfoDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<UserInfoDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPut]
        public Task<UserInfoDto> UpdateAsync(UserInfoModel input)
        {
            return _service.UpdateAsync(input);
        }
    }
}