using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Auth.Dto.Output;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Auth
{
    /// <summary>
    /// 权限服务
    /// </summary>
    public interface IAuthService : IApplicationService
    {
        Task<AuthLoginOutput> LoginAsync(AuthLoginInput input);

        Task<AuthUserInfoOutput> GetUserInfoAsync();

        Task<GetPassWordEncryptKeyOutput> GetPassWordEncryptKeyAsync();

        Task<IEnumerable<string>> GetPermissionsCodeListAsync(Guid? userId);
    }
}