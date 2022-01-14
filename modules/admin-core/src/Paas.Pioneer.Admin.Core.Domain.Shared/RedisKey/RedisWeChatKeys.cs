using Microsoft.Extensions.Options;
using Paas.Pioneer.Domain.Shared.Configs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey
{
    /// <summary>
    /// 微信Redis缓存
    /// </summary>
    public class RedisWeChatKeys : ISingletonDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly AppConfig _appConfig;

        public RedisWeChatKeys(ICurrentTenant currentTenant,
            IOptions<AppConfig> appConfig)
        {
            _currentTenant = currentTenant;
            _appConfig = appConfig.Value;
        }

        /// <summary>
        /// 根目录
        /// </summary>
        private string redisWeChat()
        {
            if (_appConfig.Tenant)
            {
                return $"{_currentTenant.Id}:WeChat";
            }
            return $"WeChat";
        }

        /// <summary>
        /// OAuth目录
        /// </summary>
        private string redisOAuthWeChat => "OAuth";

        /// <summary>
        /// accessToken （OAuth模式）
        /// </summary>
        public string accessToken => $"{redisWeChat}:{redisOAuthWeChat}:AccessToken:";

        /// <summary>
        /// refreshToken （OAuth模式）
        /// </summary>
        public string refreshToken => $"{redisWeChat}:{redisOAuthWeChat}:RefreshToken:";
    }
}
