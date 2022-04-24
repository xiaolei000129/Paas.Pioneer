using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Domain.Shared
{
    /// <summary>
    /// 返回结果格式化
    /// </summary>
    public class ResultWrapperFilter : ActionFilterAttribute, ITransientDependency
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor == null)
            {
                return;
            }

            //如果包含NoWrapperAttribute则说明不需要对返回结果进行包装，直接返回原始值
            if ((controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(NoWrapperAttribute), false)).Any())
            {
                return;
            }

            if ((controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(NoWrapperAttribute), false)).Any())
            {
                return;
            }
            //根据实际需求进行具体实现
            if (CheckVaildResult(context.Result, out var data))
            {
                var objectResult = context.Result as ObjectResult;
                //如果返回结果已经是ResponseOutput<T>类型的则不需要进行再次包装了
                if (objectResult != null && objectResult.DeclaredType.IsGenericType && objectResult.DeclaredType?.GetGenericTypeDefinition() == typeof(ResponseOutput<>))
                {
                    return;
                }
                context.Result = new ObjectResult(ResponseOutput.Succees(data));
            }
        }

        /// <summary>
        /// 检查是否是有效的结果（可进行规范化的结果）
        /// </summary>
        /// <param name="result"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CheckVaildResult(IActionResult result, out object data)
        {
            data = default;

            // 排除以下结果，跳过规范化处理
            var isDataResult = result switch
            {
                ViewResult => false,
                PartialViewResult => false,
                FileResult => false,
                ChallengeResult => false,
                SignInResult => false,
                SignOutResult => false,
                RedirectToPageResult => false,
                RedirectToRouteResult => false,
                RedirectResult => false,
                RedirectToActionResult => false,
                LocalRedirectResult => false,
                ForbidResult => false,
                ViewComponentResult => false,
                PageResult => false,
                _ => true,
            };

            // 目前支持返回值 ActionResult
            if (isDataResult) data = result switch
            {
                // 处理内容结果
                ContentResult content => content.Content,
                // 处理对象结果
                ObjectResult obj => obj.Value,
                // 处理 JSON 对象
                JsonResult json => json.Value,
                _ => null,
            };

            return isDataResult;
        }
    }
}
