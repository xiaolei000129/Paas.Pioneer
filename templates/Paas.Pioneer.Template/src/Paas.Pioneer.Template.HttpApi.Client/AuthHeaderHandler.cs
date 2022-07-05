using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Template.HttpApi.Client
{
    public class AuthHeaderHandler : DelegatingHandler, ITransientDependency
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHeaderHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = GetTokenFromHttpHeader() ?? GetTokenFromCookie();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("X-Tenant-Id", GetTenantFromHttpHeader() ?? GetTenantFromCookie());

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        protected virtual string GetTokenFromHttpHeader()
        {
            if (_httpContextAccessor.HttpContext?.Request?.Headers == null)
                return null;

            return _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var jwt) ? jwt.FirstOrDefault().Replace("Bearer ", string.Empty) : null;
        }

        protected virtual string GetTokenFromCookie()
        {
            if (_httpContextAccessor.HttpContext?.Request?.Cookies == null)
                return null;

            return _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("JWT", out var token) ? token : null;
        }

        protected virtual string GetTenantFromHttpHeader()
        {
            if (_httpContextAccessor.HttpContext?.Request?.Headers == null)
                return null;

            return _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("__tenant", out var tenant) ? tenant.FirstOrDefault() : null;
        }

        protected virtual string GetTenantFromCookie()
        {
            if (_httpContextAccessor.HttpContext?.Request?.Cookies == null)
                return null;

            return _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("__tenant", out var tenant) ? tenant : null;
        }
    }
}
