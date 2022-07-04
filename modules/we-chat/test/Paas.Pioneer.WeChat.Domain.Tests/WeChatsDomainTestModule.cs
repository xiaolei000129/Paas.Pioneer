using Paas.Pioneer.WeChat.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.WeChat.Domain.Tests
{
    [DependsOn(
        typeof(WeChatsEntityFrameworkCoreTestModule)
        )]
    public class WeChatsDomainTestModule : AbpModule
    {

    }
}