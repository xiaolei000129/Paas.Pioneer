using System;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatApps;
using Paas.Pioneer.WeChat.Application.Contracts.WeChatApps.Dtos;
using Paas.Pioneer.WeChat.Domain.WeChatApps;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.WeChat.Application.WeChatApps
{
    public class WeChatAppAppService : CrudAppService<WeChatApp, WeChatAppDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateWeChatAppDto, CreateUpdateWeChatAppDto>,
        IWeChatAppAppService
    {
        private readonly IWeChatAppRepository _repository;

        public WeChatAppAppService(IWeChatAppRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}