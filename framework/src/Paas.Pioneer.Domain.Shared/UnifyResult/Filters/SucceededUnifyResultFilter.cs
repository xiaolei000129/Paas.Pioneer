using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Paas.Pioneer.Domain.Shared.DataValidation.Internal;
using Paas.Pioneer.Domain.Shared.UnifyResult.Providers;
using System.Threading.Tasks;

namespace Furion.UnifyResult
{
	/// <summary>
	/// 规范化结构（请求成功）过滤器
	/// </summary>
	public class SucceededUnifyResultFilter : IAsyncActionFilter, IOrderedFilter
	{
		private readonly IUnifyResultProvider _unifyResultProvider;
		public SucceededUnifyResultFilter(IUnifyResultProvider unifyResultProvider)
		{
			_unifyResultProvider = unifyResultProvider;
		}

		/// <summary>
		/// 过滤器排序
		/// </summary>
		internal const int FilterOrder = 8888;

		/// <summary>
		/// 排序属性
		/// </summary>
		public int Order => FilterOrder;

		/// <summary>
		/// 处理规范化结果
		/// </summary>
		/// <param name="context"></param>
		/// <param name="next"></param>
		/// <returns></returns>
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			// 执行 Action 并获取结果
			var actionExecutedContext = await next();

			// 如果出现异常，则不会进入该过滤器
			if (actionExecutedContext.Exception != null) return;

			// 处理 BadRequestObjectResult 类型规范化处理
			if (actionExecutedContext.Result is BadRequestObjectResult badRequestObjectResult)
			{
				// 解析验证消息
				var validationMetadata = ValidatorContext.GetValidationMetadata(badRequestObjectResult.Value);

				var result = _unifyResultProvider.OnValidateFailed(context, validationMetadata);
				if (result != null) actionExecutedContext.Result = result;
			}
			else
			{
				// 目前支持返回值 ActionResult
				var data = actionExecutedContext.Result switch
				{
					// 处理内容结果
					ContentResult content => content.Content,
					// 处理对象结果
					ObjectResult obj => obj.Value,
					// 处理 JSON 对象
					JsonResult json => json.Value,
					_ => null,
				};
				IActionResult result = _unifyResultProvider.OnSucceeded(actionExecutedContext, data: data);

				// 如果是不能规范化的结果类型，则跳过
				if (result == null) return;

				actionExecutedContext.Result = result;
			}
		}
	}
}