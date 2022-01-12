using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey
{
    /// <summary>
    /// 验证码key
    /// </summary>
    public class RedisAuthCodeKeys : ISingletonDependency
    {
        private readonly ICurrentTenant _currentTenant;

        public RedisAuthCodeKeys(ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }

        /// <summary>
        /// 根目录
        /// </summary>
        private string redisAuth => $"{_currentTenant.Id}:redisAuth";

        /// <summary>
        /// 注册
        /// </summary>
        public string Register => $"{redisAuth}:Register:";

        /// <summary>
        /// 登录
        /// </summary>
        public string Login => $"{redisAuth}:Login:";

        /// <summary>
        /// 修改账号密码
        /// </summary>
        public string UpdatePassword => $"{redisAuth}:UpdatePassword:";

        /// <summary>
        /// 绑定手机号
        /// </summary>
        public string BindPhone => $"{redisAuth}:BindPhone:";

        /// <summary>
        /// 图形验证码
        /// </summary>
        public string ImageVerifyCode => $"{redisAuth}:ImageVerifyCode:";
    }
}
