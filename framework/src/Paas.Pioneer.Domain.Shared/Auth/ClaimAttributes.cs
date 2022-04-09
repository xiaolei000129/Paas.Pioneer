using Volo.Abp.Security.Claims;

namespace Paas.Pioneer.Domain.Shared.Auth
{
    /// <summary>
    /// Claim属性
    /// </summary>
    public static class ClaimAttributes
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public static string UserId { get; set; } = AbpClaimTypes.UserId;

        /// <summary>
        /// 认证授权用户Id
        /// </summary>
        public static string IdentityServerUserId { get; set; } = "sub";

        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName { get; set; } = AbpClaimTypes.Name;

        /// <summary>
        /// 姓名
        /// </summary>
        public static string UserNickName { get; set; } = AbpClaimTypes.UserName;

        /// <summary>
        /// 刷新有效期
        /// </summary>
        public static string RefreshExpires { get; set; } = "re";

        /// <summary>
        /// 租户Id
        /// </summary>
        public static string TenantId { get; set; } = AbpClaimTypes.TenantId;

        /// <summary>
        /// 租户类型
        /// </summary>
        public static string TenantType { get; set; } = "tt";

        /// <summary>
        /// 数据隔离
        /// </summary>
        public static string DataIsolationType { get; set; } = "dit";

        /// <summary>
        /// 权限
        /// </summary>
        public static string Role { get; set; } = AbpClaimTypes.Role;


    }
}