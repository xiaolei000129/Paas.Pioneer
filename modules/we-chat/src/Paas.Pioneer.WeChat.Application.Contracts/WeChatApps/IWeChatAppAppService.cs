using System;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatApps.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.WeChat.Application.Contracts.WeChatApps
{
    public interface IWeChatAppAppService :
        ICrudAppService<
            WeChatAppDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateWeChatAppDto,
            CreateUpdateWeChatAppDto>
    {

    }
}