using Paas.Pioneer.WeChat.Application;
using Paas.Pioneer.WeChat.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.WeChat.Application.Tests
{
    [DependsOn(
        typeof(WeChatsApplicationModule),
        typeof(WeChatsDomainTestModule)
        )]
    public class WeChatsApplicationTestModule : AbpModule
    {

    }
}