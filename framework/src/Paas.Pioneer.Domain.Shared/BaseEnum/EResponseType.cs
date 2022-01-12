using System.ComponentModel;

namespace Paas.Pioneer.Domain.Shared.BaseEnum
{
	/// <summary>
	/// 请求响应码
	/// </summary>
	public enum EResponseType
	{
		/// <summary>
		/// 请求成功
		/// </summary>
		[Description("请求成功")]
		Succees = 0,
		/// <summary>
		/// 请求失败
		/// </summary>
		[Description("请求失败")]
		Fail = 500,
	}
}
