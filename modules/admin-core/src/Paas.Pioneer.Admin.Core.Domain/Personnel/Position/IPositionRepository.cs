using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Personnel.Position
{
    public interface IPositionRepository : IRepository<Pe_PositionEntity, Guid>, IBaseExtensionRepository<Pe_PositionEntity>
    {

    }
}
