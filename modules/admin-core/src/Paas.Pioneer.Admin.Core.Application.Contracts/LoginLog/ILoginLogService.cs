using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog
{
    public interface ILoginLogService : IApplicationService
    {
        Task<ResponseOutput<Page<LoginLogOutput>>> GetPageListAsync(PageInput<LoginLogModel> input);

        Task<ResponseOutput<Guid>> AddAsync(LoginLogAddInput input);
    }
}