using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Role
{
    public interface IRoleRepository : IRepository<Ad_RoleEntity, Guid>, IBaseExtensionRepository<Ad_RoleEntity>
    {

    }
}
