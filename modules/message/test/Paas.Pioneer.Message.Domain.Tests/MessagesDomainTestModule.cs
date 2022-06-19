using Paas.Pioneer.Message.EntityFrameworkCore.Tests.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.Message.Domain.Tests
{
    [DependsOn(
        typeof(MessagesEntityFrameworkCoreTestModule)
        )]
    public class MessagesDomainTestModule : AbpModule
    {

    }
}