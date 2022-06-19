using System;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.SignalR
{
    [DependsOn(
    typeof(AbpAspNetCoreSignalRModule)
    )]
    public class SignalRModule : AbpModule
    {
    }
}
