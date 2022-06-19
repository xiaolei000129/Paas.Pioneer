using Paas.Pioneer.Message.Application;
using Paas.Pioneer.Message.Domain.Tests;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Message.Application.Tests
{
    [DependsOn(
        typeof(MessagesApplicationModule),
        typeof(MessagesDomainTestModule)
        )]
    public class MessagesApplicationTestModule : AbpModule
    {

    }
}