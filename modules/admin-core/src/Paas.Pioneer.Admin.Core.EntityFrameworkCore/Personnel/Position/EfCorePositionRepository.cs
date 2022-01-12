using Paas.Pioneer.Admin.Core.Domain.Personnel.Position;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Personnel.Position
{
    public class EfCorePositionRepository : BaseExtensionsRepository<Pe_PositionEntity>, IPositionRepository
    {
        public EfCorePositionRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
