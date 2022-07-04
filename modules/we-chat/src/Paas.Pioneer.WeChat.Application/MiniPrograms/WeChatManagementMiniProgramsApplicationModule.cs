using System;
using EasyAbp.Abp.WeChat.MiniProgram;
using EasyAbp.Abp.WeChat.MiniProgram.Infrastructure.OptionsResolve;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Paas.Pioneer.WeChat.Domain.MiniPrograms;
using Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms;
using Paas.Pioneer.WeChat.Application.WeChat;

namespace Paas.Pioneer.WeChat.Application.MiniPrograms
{
    [DependsOn(
        typeof(WeChatManagementMiniProgramsDomainModule),
        typeof(WeChatManagementMiniProgramsApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpWeChatMiniProgramModule)
    )]
    public class WeChatManagementMiniProgramsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<WeChatManagementMiniProgramsApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<WeChatManagementMiniProgramsApplicationModule>(validate: true);
            });

            context.Services.AddHttpClient(WeChatMiniProgramConsts.IdentityServerHttpClientName, c =>
            {
                c.Timeout = TimeSpan.FromMilliseconds(5000);
            });

            Configure<AbpWeChatMiniProgramResolveOptions>(options =>
            {
                if (!options.Contributors.Exists(x => x.Name == ClaimsWeChatMiniProgramOptionsResolveContributor.ContributorName))
                {
                    options.Contributors.Insert(0, new ClaimsWeChatMiniProgramOptionsResolveContributor());
                }
            });
        }
    }
}
