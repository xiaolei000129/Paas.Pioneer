using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Api
{
    public interface IApiRepository : IRepository<Ad_ApiEntity, Guid>, IBaseExtensionRepository<Ad_ApiEntity>
    {

    }
}
