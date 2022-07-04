using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms.Localization;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.WeChat.Application.MiniPrograms
{
    public abstract class MiniProgramsAppService : ApplicationService
    {
        protected MiniProgramsAppService()
        {
            LocalizationResource = typeof(MiniProgramsResource);
            ObjectMapperContext = typeof(WeChatManagementMiniProgramsApplicationModule);
        }
    }
}
