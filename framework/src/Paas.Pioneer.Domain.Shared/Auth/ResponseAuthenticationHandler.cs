using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Paas.Pioneer.Domain.Shared.Auth
{
	/// <summary>
	/// 响应认证处理器
	/// </summary>
	public class ResponseAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		public ResponseAuthenticationHandler(
			IOptionsMonitor<AuthenticationSchemeOptions> _options,
			ILoggerFactory _logger,
			UrlEncoder _encoder,
			ISystemClock _clock
		) : base(_options, _logger, _encoder, _clock)
		{
		}

		protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			throw new NotImplementedException();
		}

		protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
		{
			Response.ContentType = "application/json";
			Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized;
			await Response.WriteAsync(JsonConvert.SerializeObject(
				new ResponseStatusData
				{
					Code = StatusCodes.Status401Unauthorized,
					Msg = StatusCodes.Status401Unauthorized.ToDescription()
				},
				new JsonSerializerSettings()
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				}
			));
		}

		protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
		{
			Response.ContentType = "application/json";
			Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden;
			await Response.WriteAsync(JsonConvert.SerializeObject(
				new ResponseStatusData
				{
					Code = StatusCodes.Status403Forbidden,
					Msg = StatusCodes.Status403Forbidden.ToDescription()
				},
				new JsonSerializerSettings()
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				}
			));
		}
	}

	public class ResponseStatusData
	{
		public StatusCodes Code { get; set; }
		public string Msg { get; set; }
	}

	/// <summary>
	/// 状态码枚举
	/// </summary>
	public enum StatusCodes
	{
		/// <summary>
		/// 操作失败
		/// </summary>
		[Description("操作失败")]
		Status0NotOk = 0,

		/// <summary>
		/// 操作成功
		/// </summary>
		[Description("操作成功")]
		Status1Ok = 1,

		/// <summary>
		/// 未登录（需要重新登录）
		/// </summary>
		[Description("未登录")]
		Status401Unauthorized = 401,

		/// <summary>
		/// 权限不足
		/// </summary>
		[Description("权限不足")]
		Status403Forbidden = 403,

		/// <summary>
		/// 资源不存在
		/// </summary>
		[Description("资源不存在")]
		Status404NotFound = 404,

		/// <summary>
		/// 系统内部错误（非业务代码里显式抛出的异常，例如由于数据不正确导致空指针异常、数据库异常等等）
		/// </summary>
		[Description("系统内部错误")]
		Status500InternalServerError = 500
	}
}