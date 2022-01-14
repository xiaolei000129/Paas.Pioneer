using Hangfire.Dashboard;
using System.Diagnostics.CodeAnalysis;

namespace Paas.Pioneer.Hangfire.HttpApi.Host.Filter
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
