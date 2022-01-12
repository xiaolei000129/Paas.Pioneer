using Paas.Pioneer.Template.EntityFrameworkCore.Tests.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace Paas.Pioneer.Template.EntityFrameworkCore.Tests.EntityFrameworkCore.Samples
{
    /* This is just an example test class.
     * Normally, you don't test ABP framework code
     * (like default AppUser repository IRepository<AppUser, Guid> here).
     * Only test your custom repository methods.
     */
    public class SampleRepositoryTests : TemplatesEntityFrameworkCoreTestBase
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
