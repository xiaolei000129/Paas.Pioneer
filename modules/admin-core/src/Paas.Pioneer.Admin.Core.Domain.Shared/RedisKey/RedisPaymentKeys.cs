using Microsoft.Extensions.Options;
using Paas.Pioneer.Domain.Shared.Configs;
using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey
{
    /// <summary>
    /// 支付缓存key
    /// </summary>
    public class RedisPaymentKeys : ISingletonDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly AppConfig _appConfig;

        public RedisPaymentKeys(ICurrentTenant currentTenant,
            IOptions<AppConfig> appConfig)
        {
            _currentTenant = currentTenant;
            _appConfig = appConfig.Value;
        }


        /// <summary>
        /// 根目录
        /// </summary>
        private string payment()
        {
            if (_appConfig.Tenant)
            {
                return $"{_currentTenant.Id}:Payment";
            }
            return "Payment";
        }

        /// <summary>
        /// 支付锁
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string PaymentLock(Guid? userId) => $"{payment()}:{userId}";

    }
}
