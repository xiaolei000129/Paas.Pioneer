using Paas.Pioneer.Admin.Core.Domain.Role;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Role
{
    public class EfCoreRoleRepository : BaseExtensionsRepository<Ad_RoleEntity>, IRoleRepository
    {
        public EfCoreRoleRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
