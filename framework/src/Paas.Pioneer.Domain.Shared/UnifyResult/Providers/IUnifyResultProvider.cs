using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Paas.Pioneer.Domain.Shared.DataValidation.Internal;
using System.Threading.Tasks;

namespace Paas.Pioneer.Domain.Shared.UnifyResult.Providers
{
	/// <summary>
	/// 规范化结果提供器
	/// </summary>
	public interface IUnifyResultProvider
    {
        /// <summary>
        /// 异常返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        //IActionResult OnException(ExceptionContext context);

        /// <summary>
        /// 成功返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        IActionResult OnSucceeded(ActionExecutedContext context, object data);

        /// <summary>
        /// 验证失败返回值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        IActionResult OnValidateFailed(ActionExecutingContext context, ValidationMetadata metadata);
    }

}
