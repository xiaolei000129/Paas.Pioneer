using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.AutoWrapper.Attributes;
using System.Linq;

namespace Paas.Pioneer.Domain.Shared
{
    /// <summary>
    /// 返回结果格式化
    /// </summary>
    public class ResultWrapperFilter : ActionFilterAttribute
    {
        private readonly IResponseOutput<object> _result;
        public ResultWrapperFilter(IResponseOutput<object> result)
        {
            _result = result;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor == null)
            {
                return;
            }

            //如果包含NoWrapperAttribute则说明不需要对返回结果进行包装，直接返回原始值
            if ((controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(NoAutoWrapperAttribute), false)).Any())
            {
                return;
            }

            if ((controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(NoAutoWrapperAttribute), false)).Any())
            {
                return;
            }

            //根据实际需求进行具体实现
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                //如果返回结果已经是ResponseOutput<T>类型的则不需要进行再次包装了
                if (objectResult == null || (objectResult.DeclaredType.IsGenericType && objectResult.DeclaredType?.GetGenericTypeDefinition() == typeof(ResponseOutput<>)))
                {
                    return;
                }
                context.Result = new ObjectResult(_result.Succees(objectResult.Value));
            }

            // 没有返回值
            if (context.Result is EmptyResult)
            {
                context.Result = new ObjectResult(_result.Succees());
            }
        }
    }
}
