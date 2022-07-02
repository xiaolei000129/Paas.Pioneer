using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.AutoWrapper.Attributes;
using Paas.Pioneer.Domain.Shared.Filter;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Paas.Pioneer.Domain.Shared.Provider
{
    public class ResultWrapperApplicationModelProvider : IApplicationModelProvider
    {
        private readonly ILogger<ResultWrapperApplicationModelProvider> _logger;
        private readonly IResponseOutput<object> _result;
        private readonly Type _responseWrapperType;
        public ResultWrapperApplicationModelProvider(ILogger<ResultWrapperApplicationModelProvider> logger,
            IResponseOutput<object> result)
        {
            _logger = logger;
            _result = result;
            _responseWrapperType = _result.GetType();
        }

        public int Order => -1000 + 20;

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            // Method intentionally left empty.
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            foreach (var controllerModel in context.Result.Controllers)
            {
                if (IsApiController(controllerModel))
                {
                    continue;
                }

                foreach (var actionModel in controllerModel.Actions)
                {
                    if (actionModel.Attributes.OfType<NoAutoWrapperAttribute>().Any()) continue;
                    actionModel.Filters.Add(new ResultWrapperFilter(_result));
                    AddResponseWrapperFilter(actionModel);
                }
            }
        }

        private void AddResponseWrapperFilter(ActionModel actionModel)
        {
            const int statusCode = StatusCodes.Status200OK;
            var responseType = actionModel.ActionMethod.ReturnType;
            if (responseType.IsAssignableTo(typeof(IConvertToActionResult)))
            {
                AddIActionResultWrapperFilter(responseType);
                return;
            }

            if (responseType == typeof(void) || responseType == typeof(Task))
            {
                AddWrapperFilter();
                return;
            }

            if (responseType.BaseType == typeof(Task))
            {
                var genericArgument = responseType.GetGenericArguments()[0];
                if (genericArgument.IsAssignableTo(typeof(IConvertToActionResult)))
                {
                    AddIActionResultWrapperFilter(genericArgument);
                    return;
                }

                AddGenericWrapperFilter(genericArgument);
                return;
            }

            AddGenericWrapperFilter(responseType);

            void AddWrapperFilter()
            {
                actionModel.Filters.Add(new ProducesResponseTypeAttribute(_responseWrapperType, statusCode));
            }

            void AddGenericWrapperFilter(Type type)
            {
                actionModel.Filters.Add(
                    new ProducesResponseTypeAttribute(_responseWrapperType.MakeGenericType(type), statusCode));
            }

            // Add wrapper filter for the type is assignable to IConvertToActionResult
            void AddIActionResultWrapperFilter(Type type)
            {
                if (type.GetGenericArguments().Any())
                {
                    var genericType = type.GetGenericArguments()[0];
                    AddGenericWrapperFilter(genericType);
                    return;
                }

                AddWrapperFilter();
            }
        }

        private static bool IsApiController(ControllerModel controller)
        {
            if (controller.Attributes.OfType<IApiBehaviorMetadata>().Any())
            {
                return true;
            }

            var controllerAssembly = controller.ControllerType.Assembly;
            var assemblyAttributes = controllerAssembly.GetCustomAttributes();
            return assemblyAttributes.OfType<IApiBehaviorMetadata>().Any();
        }
    }
}
