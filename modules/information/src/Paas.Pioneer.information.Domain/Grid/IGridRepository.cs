using Paas.Pioneer.Information.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Information.Domain.Grid
{
    public interface IGridRepository : IRepository<Information_GridEntity, Guid>, IBaseExtensionRepository<Information_GridEntity>
    {

    }
}
