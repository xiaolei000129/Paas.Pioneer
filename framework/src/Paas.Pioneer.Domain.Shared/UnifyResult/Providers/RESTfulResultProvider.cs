using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Paas.Pioneer.Domain.Shared.DataValidation.Internal;
using Paas.Pioneer.Domain.Shared.UnifyResult.Internal;
using System;

namespace Paas.Pioneer.Domain.Shared.UnifyResult.Providers
{
    public class RESTfulResultProvider : IUnifyResultProvider
	{
		/// <summary>
		/// 异常返回值
		/// </summary>
		/// <param name="context"></param>
		/// <param name="metadata"></param>
		/// <returns></returns>
		//public IActionResult OnException(ExceptionContext context, ExceptionMetadata metadata)
		//{
		//	return new JsonResult(RESTfulResult(metadata.StatusCode, errors: metadata.Errors));
		//}

		/// <summary>
		/// 成功返回值
		/// </summary>
		/// <param name="context"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public IActionResult OnSucceeded(ActionExecutedContext context, object data)
		{
			return new JsonResult(RESTfulResult(StatusCodes.Status200OK, true, data));
		}

		/// <summary>
		/// 验证失败返回值
		/// </summary>
		/// <param name="context"></param>
		/// <param name="metadata"></param>
		/// <returns></returns>
		public IActionResult OnValidateFailed(ActionExecutingContext context, ValidationMetadata metadata)
		{
			return new JsonResult(RESTfulResult(StatusCodes.Status400BadRequest, errors: metadata.ValidationResult));
		}

		/// <summary>
		/// 返回 RESTful 风格结果集
		/// </summary>
		/// <param name="statusCode"></param>
		/// <param name="succeeded"></param>
		/// <param name="data"></param>
		/// <param name="errors"></param>
		/// <returns></returns>
		private static RESTfulResult<object> RESTfulResult(int statusCode, bool succeeded = true, object data = default, object errors = default)
		{
			return new RESTfulResult<object>
			{
				StatusCode = statusCode,
				Succeeded = succeeded,
				Data = data,
				Errors = errors,
				Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
			};
		}
	}
}
