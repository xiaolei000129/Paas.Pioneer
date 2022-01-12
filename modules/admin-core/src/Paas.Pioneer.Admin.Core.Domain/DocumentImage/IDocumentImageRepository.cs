using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.DocumentImage
{
    public interface IDocumentImageRepository : IRepository<Ad_DocumentImageEntity, Guid>, IBaseExtensionRepository<Ad_DocumentImageEntity>
    {

    }
}
