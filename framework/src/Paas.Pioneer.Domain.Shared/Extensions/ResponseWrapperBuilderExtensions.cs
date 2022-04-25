using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Paas.Pioneer.Domain.Shared.Provider;

namespace Paas.Pioneer.Domain.Shared.Extensions
{
    public static class ResponseWrapperBuilderExtensions
    {
        public static IMvcBuilder AddResponseWrapper(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            mvcBuilder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, ResultWrapperApplicationModelProvider>());
            return mvcBuilder;
        }
    }
}
