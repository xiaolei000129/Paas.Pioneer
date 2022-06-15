using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.DynamicProxy
{
    [DependsOn()]
    public class DynamicProxyModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddScoped<IProxyHandle, ProxyHandleTest>();
        }
    }
}
