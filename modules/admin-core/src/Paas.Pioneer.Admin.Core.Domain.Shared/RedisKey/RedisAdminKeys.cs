using Microsoft.Extensions.Options;
using Paas.Pioneer.Domain.Shared.Configs;
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
        private readonly AppConfig _appConfig;

        public RedisAdminKeys(ICurrentTenant currentTenant,
            IOptions<AppConfig> appConfig)
        {
            _currentTenant = currentTenant;
            _appConfig = appConfig.Value;
        }

        /// <summary>
        /// 后端管理根目录
        /// </summary>
        /// <returns></returns>
        private string Admin()
        {
            if (_appConfig.Tenant)
            {
                return $"{_currentTenant.Id}:Admin";
            }
            return "Admin";
        }

        /// <summary>
        /// 验证码 admin:verify:code:guid
        /// </summary>
        [Description("验证码")]
        public string VerifyCodeKey => string.Format("{0}:Verify:Code:{1}", this.Admin(), "{0}");

        /// <summary>
        /// 密码加密 admin:password:encrypt:guid
        /// </summary>
        [Description("密码加密")]
        public string PassWordEncryptKey => string.Format("{0}:Password:Encrypt:{1}", this.Admin(), "{0}");

        /// <summary>
        /// 用户权限 admin:user:permissions:用户主键
        /// </summary>
        [Description("用户权限")]
        public string UserPermissions => string.Format("{0}:User:Permissions:{1}", this.Admin(), "{0}");

        /// <summary>
        /// 用户信息 admin:user:info:用户主键
        /// </summary>
        [Description("用户信息")]
        public string UserInfo => string.Format("{0}:User:Info:{1}", this.Admin(), "{0}");

        /// <summary>
        /// 租户信息 admin:tenant:info:租户主键
        /// </summary>
        [Description("租户信息")]
        public string TenantInfo => string.Format("{0}:Tenant:Info:{1}", this.Admin(), "{0}");
    }
}