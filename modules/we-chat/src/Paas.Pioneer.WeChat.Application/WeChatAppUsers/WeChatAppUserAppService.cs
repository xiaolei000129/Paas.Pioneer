using System;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatAppUsers;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatAppUsers.Dtos;
using Paas.Pioneer.WeChat.Domain.WeChatAppUsers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.WeChat.Application.WeChatAppUsers
{
    public class WeChatAppUserAppService : ReadOnlyAppService<WeChatAppUser, WeChatAppUserDto, Guid, PagedAndSortedResultRequestDto>,
        IWeChatAppUserAppService
    {
        private readonly IWeChatAppUserRepository _repository;

        public WeChatAppUserAppService(IWeChatAppUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}