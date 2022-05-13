using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using Volo.Abp;
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
            throw new BusinessException(errorMessage);
        }
    }
}
