using System.ComponentModel;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.RedisKey
{
    /// <summary>
    /// 缓存键
    /// </summary>
    public class RedisAdminKeys : ISingletonDependency
    {

        private readonly ICurrentTenant _currentTenant;

        public RedisAdminKeys(ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }

        /// <summary>
        /// 验证码 admin:verify:code:guid
        /// </summary>
        [Description("验证码")]
        public string VerifyCodeKey => string.Format("{0}:admin:verify:code:{1}", _currentTenant.Id, "{0}");

        /// <summary>
        /// 密码加密 admin:password:encrypt:guid
        /// </summary>
        [Description("密码加密")]
        public string PassWordEncryptKey => string.Format("{0}:admin:password:encrypt:{1}", _currentTenant.Id, "{0}");

        /// <summary>
        /// 用户权限 admin:user:permissions:用户主键
        /// </summary>
        [Description("用户权限")]
        public string UserPermissions => string.Format("{0}:admin:user:permissions:{1}", _currentTenant.Id, "{0}");

        /// <summary>
        /// 用户信息 admin:user:info:用户主键
        /// </summary>
        [Description("用户信息")]
        public string UserInfo => string.Format("{0}:admin:user:info:{1}", _currentTenant.Id, "{0}");

        /// <summary>
        /// 租户信息 admin:tenant:info:租户主键
        /// </summary>
        [Description("租户信息")]
        public string TenantInfo => string.Format("{0}:admin:tenant:info:{1}", _currentTenant.Id, "{0}");
    }
}