using System;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatAppUsers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.WeChat.Application.Contracts.WeChatAppUsers
{
    public interface IWeChatAppUserAppService :
        IReadOnlyAppService<
            WeChatAppUserDto,
            Guid,
            PagedAndSortedResultRequestDto>
    {

    }
}