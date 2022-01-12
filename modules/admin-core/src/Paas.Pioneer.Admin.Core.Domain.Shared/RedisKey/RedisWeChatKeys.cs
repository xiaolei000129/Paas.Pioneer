using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public RedisWeChatKeys(ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }

        /// <summary>
        /// 根目录
        /// </summary>
        private string redisWeChat => $"{_currentTenant.Id}:WeChat";

        /// <summary>
        /// OAuth目录
        /// </summary>
        private string redisOAuthWeChat => "OAuth";

        /// <summary>
        /// accessToken （OAuth模式）
        /// </summary>
        public string accessToken => $"{redisWeChat}:{redisOAuthWeChat}:accessToken:";

        /// <summary>
        /// refreshToken （OAuth模式）
        /// </summary>
        public string refreshToken => $"{redisWeChat}:{redisOAuthWeChat}:refreshToken:";
    }
}
