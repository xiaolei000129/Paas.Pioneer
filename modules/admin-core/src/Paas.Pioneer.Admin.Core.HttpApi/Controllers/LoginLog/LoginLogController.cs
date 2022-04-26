using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 登录日志管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class LoginLogController : AbpControllerBase
    {
        private readonly ILoginLogService _loginLogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="loginLogService"></param>
        public LoginLogController(ILoginLogService loginLogService)
        {
            _loginLogService = loginLogService;
        }

        /// <summary>
        /// 查询分页登录日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseOutput<Page<LoginLogOutput>>> GetPageList(PageInput<LoginLogModel> model)
        {
            return await _loginLogService.GetPageListAsync(model);
        }
    }
}