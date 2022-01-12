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
		public static string UserId = AbpClaimTypes.UserId;

		/// <summary>
		/// 认证授权用户Id
		/// </summary>
		public static string IdentityServerUserId = "sub";

		/// <summary>
		/// 用户名
		/// </summary>
		public static string UserName = AbpClaimTypes.Name;

		/// <summary>
		/// 姓名
		/// </summary>
		public static string UserNickName = AbpClaimTypes.UserName;

		/// <summary>
		/// 刷新有效期
		/// </summary>
		public static string RefreshExpires = "re";

		/// <summary>
		/// 租户Id
		/// </summary>
		public static string TenantId = AbpClaimTypes.TenantId;

		/// <summary>
		/// 租户类型
		/// </summary>
		public static string TenantType = "tt";

		/// <summary>
		/// 数据隔离
		/// </summary>
		public static string DataIsolationType = "dit";

		/// <summary>
		/// 权限
		/// </summary>
		public static string Role = AbpClaimTypes.Role;

		
	}
}