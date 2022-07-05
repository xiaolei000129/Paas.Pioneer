using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatAppUsers;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatAppUsers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.WeChat.HttpApi.Controllers.WeChatAppUsers;

[Route("/api/wechat-management/wechat-app-user")]
public class WeChatAppUserController : AbpController
{
    private readonly IWeChatAppUserAppService _service;

    public WeChatAppUserController(IWeChatAppUserAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id}")]
    public Task<WeChatAppUserDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    public Task<PagedResultDto<WeChatAppUserDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _service.GetListAsync(input);
    }
}