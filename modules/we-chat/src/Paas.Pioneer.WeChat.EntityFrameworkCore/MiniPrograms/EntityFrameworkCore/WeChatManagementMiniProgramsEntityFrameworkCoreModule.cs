using EasyAbp.WeChatManagement.Common.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paas.Pioneer.WeChat.Domain.MiniPrograms;
using Paas.Pioneer.WeChat.Domain.MiniPrograms.UserInfos;
using Paas.Pioneer.WeChat.EntityFrameworkCore.MiniPrograms.UserInfos;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.MiniPrograms.EntityFrameworkCore
{
    [DependsOn(
        typeof(WeChatManagementMiniProgramsDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(WeChatManagementCommonEntityFrameworkCoreModule)
    )]
    public class WeChatManagementMiniProgramsEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MiniProgramsDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<UserInfo, UserInfoRepository>();
            });
        }
    }
}
