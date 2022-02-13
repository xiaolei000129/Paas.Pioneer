using Paas.Pioneer.information.Application.Tests;
using System.Threading.Tasks;
using Xunit;

namespace Paas.Pioneer.information.Application.Tests.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
    public class SampleAppServiceTests : informationsApplicationTestBase
    {
        public SampleAppServiceTests()
        {
        }

        [Fact]
        public void Initial_Data_Should_Contain_Admin_User()
        {

        }
    }
}
