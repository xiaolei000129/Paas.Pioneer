using Paas.Pioneer.WeChat.EntityFrameworkCore.Tests.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.Tests.EntityFrameworkCore.Samples
{
    /* This is just an example test class.
     * Normally, you don't test ABP framework code
     * (like default AppUser repository IRepository<AppUser, Guid> here).
     * Only test your custom repository methods.
     */
    public class SampleRepositoryTests : WeChatsEntityFrameworkCoreTestBase
    {

        public SampleRepositoryTests()
        {
        }

        [Fact]
        public void Should_Query_AppUser()
        {

        }
    }
}
