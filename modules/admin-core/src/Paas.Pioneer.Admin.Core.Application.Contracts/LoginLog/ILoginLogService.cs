using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LoginLog
{
    public interface ILoginLogService : IApplicationService
    {
        Task<Page<LoginLogOutput>> GetPageListAsync(PageInput<LoginLogModel> input);

        Task<Guid> AddAsync(LoginLogAddInput input);
    }
}