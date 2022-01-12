using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey
{
    /// <summary>
    /// 公共redids
    /// </summary>
    public class RedisCommKeys : ISingletonDependency
    {
        private readonly ICurrentTenant _currentTenant;

        public RedisCommKeys(ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }

        //根
        private string redisComm => $"{_currentTenant.Id}:redisComm";

        /// <summary>
        /// 统计
        /// </summary>
        private string statistics => $"{redisComm}:statistics";

        /// <summary>
        /// 每日访问量
        /// </summary>
        public string visit => $"{statistics}:visit:";

        /// <summary>
        /// 统计登录人数
        /// </summary>
        public string login => $"{statistics}:login:";

        /// <summary>
        /// 统计注册人数
        /// </summary>
        public string register => $"{statistics}:register:";
    }
}
