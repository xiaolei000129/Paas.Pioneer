using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.Admin.Core.HttpApi.Client;
using Paas.Pioneer.WeChat.Application.Contracts;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Paas.Pioneer.WeChat.HttpApi.Client
{
    [DependsOn(
        typeof(WeChatsApplicationContractsModule),
        typeof(AbpTenantManagementHttpApiClientModule)
    )]
    public class WeChatsHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddHttpContextAccessor();

            var httpApiClientOptions = context.Services.ExecutePreConfiguredActions<WeChatsServicesHttpApiClientOptions>();

            var hostUrl = configuration[httpApiClientOptions.RemoteSectionUrl];

            var httpClientBuilder = context.Services.AddHttpClient(httpApiClientOptions.RemoteServiceName, x =>
            {
                x.BaseAddress = new Uri(hostUrl);
            });

            if (httpApiClientOptions.DelegatingHandlerFunc != null)
            {
                httpClientBuilder.ConfigurePrimaryHttpMessageHandler(httpApiClientOptions.DelegatingHandlerFunc);
            }
            else
            {
                httpClientBuilder.ConfigurePrimaryHttpMessageHandler(x => context.Services.GetRequiredService<AuthHeaderHandler>());
            }

            var allRefitServiceProxyTypes = new List<Type>(typeof(WeChatsHttpApiClientModule).Assembly.GetTypes());

            allRefitServiceProxyTypes = allRefitServiceProxyTypes.FindAll(t => t.IsInterface && typeof(IRefitServiceProxy).IsAssignableFrom(t));

            foreach (var type in allRefitServiceProxyTypes)
            {
                AddRefitClient(context.Services, type, httpApiClientOptions.RemoteServiceName);
            }
        }

        public IServiceCollection AddRefitClient(IServiceCollection services, Type refitInterfaceType, string httpclientName, RefitSettings settings = null)
        {
            var builder = RequestBuilder.ForType(refitInterfaceType, settings);
            services.AddSingleton(provider => builder);
            services.AddSingleton(refitInterfaceType, provider =>
            {
                var client = provider.GetService<IHttpClientFactory>().CreateClient(httpclientName);
                if (client == null)
                {
                    throw new BusinessException(message: $"please inject the httpclient  named {httpclientName} httpclient!! ");
                }
                return RestService.For(refitInterfaceType, client, builder);
            });
            return services;
        }
    }
}
