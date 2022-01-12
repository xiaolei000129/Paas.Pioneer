using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.View
{
    public interface IViewRepository : IRepository<Ad_ViewEntity, Guid>, IBaseExtensionRepository<Ad_ViewEntity>
    {

    }
}
