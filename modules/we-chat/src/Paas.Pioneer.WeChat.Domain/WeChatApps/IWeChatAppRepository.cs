using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.WeChat.Domain.WeChatApps
{
    public interface IWeChatAppRepository : IRepository<WeChatApp, Guid>
    {
    }
}