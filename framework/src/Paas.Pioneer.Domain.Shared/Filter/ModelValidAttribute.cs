using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System.Linq;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Domain.Shared
{
    public class ModelValidAttribute : ActionFilterAttribute, ITransientDependency
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ModelStateDictionary modelState = context.ModelState;
            if (modelState.IsValid)
            {
                return;
            }
            var errorMessage = modelState.Where(x => x.Value.Errors.Any()).Select(x => x.Value.Errors.FirstOrDefault().ErrorMessage).FirstOrDefault();
            context.Result = new JsonResult(ResponseOutput.Error<object>(errorMessage));
            context.HttpContext.Response.StatusCode = 200;
        }
    }
}
