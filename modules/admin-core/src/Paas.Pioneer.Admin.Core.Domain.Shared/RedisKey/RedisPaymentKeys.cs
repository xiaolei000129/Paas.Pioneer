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

        public RedisPaymentKeys(ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }


        /// <summary>
        /// 根目录
        /// </summary>
        private string Payment => $"{_currentTenant.Id}:Payment";

        /// <summary>
        /// 支付锁
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string PaymentLock(Guid? userId) => $"{Payment}:{userId}";

    }
}
