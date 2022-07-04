using Paas.Pioneer.WeChat.Domain.Shared.MiniPrograms.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Paas.Pioneer.WeChat.HttpApi.Controllers.MiniPrograms
{
    public abstract class MiniProgramsController : AbpControllerBase
    {
        protected MiniProgramsController()
        {
            LocalizationResource = typeof(MiniProgramsResource);
        }
    }
}
