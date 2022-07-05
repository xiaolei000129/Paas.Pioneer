using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatApps;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatApps.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.WeChat.HttpApi.Controllers.WeChatApps;

[Route("/api/wechat-management/wechat-app")]
public class WeChatAppController : AbpController
{
    private readonly IWeChatAppAppService _appService;

    public WeChatAppController(IWeChatAppAppService appService)
    {
        _appService = appService;
    }

    [HttpGet]
    [Route("{id}")]
    public Task<WeChatAppDto> GetAsync(Guid id)
    {
        return _appService.GetAsync(id);
    }

    [HttpGet]
    public Task<PagedResultDto<WeChatAppDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _appService.GetListAsync(input);
    }

    [HttpPost]
    public Task<WeChatAppDto> CreateAsync(CreateUpdateWeChatAppDto input)
    {
        return _appService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public Task<WeChatAppDto> UpdateAsync(Guid id, CreateUpdateWeChatAppDto input)
    {
        return _appService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _appService.DeleteAsync(id);
    }
}