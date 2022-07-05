using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.User.Application.Contracts.UserInfos;
using Paas.Pioneer.User.Application.Contracts.UserInfos.Dtos;
using Paas.Pioneer.User.Domain.Shared.UserInfos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.User.HttpApi.Controllers.UserInfos
{
    [Route("/api/wechat-management/mini-programs/user-info")]
    public class UserInfoController : AbpController
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