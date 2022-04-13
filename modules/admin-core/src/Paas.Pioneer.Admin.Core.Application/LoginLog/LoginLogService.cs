using Microsoft.AspNetCore.Http;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.LoginLog;
using Paas.Pioneer.Admin.Core.Domain.Shared.Helpers;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.LoginLog
{
    public class LoginLogService : ApplicationService, ILoginLogService
    {
        private readonly IHttpContextAccessor _context;
        private readonly ILoginLogRepository _loginLogRepository;

        public LoginLogService(
            IHttpContextAccessor context,
            ILoginLogRepository loginLogRepository
        )
        {
            _context = context;
            _loginLogRepository = loginLogRepository;
        }

        public async Task<ResponseOutput<Page<LoginLogOutput>>> GetPageListAsync(PageInput<LoginLogModel> input)
        {
            var userId = input.Filter?.CreatedUserId;
            Expression<Func<Ad_LoginLogEntity, bool>> expression = x => true;
            if (userId != Guid.Empty)
            {
                expression = expression.And(a => a.CreatorId.Equals(userId));
            }
            return await _loginLogRepository.GetResponseOutputPageListAsync(expression: expression,
                selector: x => new LoginLogOutput
                {
                    Id = x.Id,
                    Browser = x.Browser,
                    BrowserInfo = x.BrowserInfo,
                    CreationTime = x.CreationTime,
                    CreatorId = x.CreatorId,
                    Device = x.Device,
                    ElapsedMilliseconds = x.ElapsedMilliseconds,
                    IP = x.IP,
                    LastModificationTime = x.LastModificationTime,
                    LastModifierId = x.LastModifierId,
                    Msg = x.Msg,
                    NickName = x.NickName,
                    Os = x.Os,
                    Result = x.Result,
                    Status = x.Status,
                },
        x => x.OrderByDescending(p => p.CreationTime),
        input);
        }

        public async Task<ResponseOutput<Guid>> AddAsync(LoginLogAddInput input)
        {
            var res = new ResponseOutput<Guid>();
            input.IP = IPHelper.GetIP(_context?.HttpContext?.Request);

            string ua = _context.HttpContext.Request.Headers["User-Agent"];
            if (!ua.IsNullOrEmpty())
            {
                var client = UAParser.Parser.GetDefault().Parse(ua);
                var device = client.Device.Family;
                device = device.ToLower() == "other" ? "" : device;
                input.Browser = client.UA.Family;
                input.Os = client.OS.Family;
                input.Device = device;
                input.BrowserInfo = ua;
            }
            var entity = ObjectMapper.Map<LoginLogAddInput, Ad_LoginLogEntity>(input);
            var id = (await _loginLogRepository.InsertAsync(entity)).Id;

            return res.Succees(id);
        }
    }
}