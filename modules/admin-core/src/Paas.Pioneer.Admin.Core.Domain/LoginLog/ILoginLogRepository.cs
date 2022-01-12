using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.LoginLog
{
    public interface ILoginLogRepository : IRepository<Ad_LoginLogEntity, Guid>, IBaseExtensionRepository<Ad_LoginLogEntity>
    {

    }
}
