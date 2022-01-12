using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Document
{
    public interface IDocumentRepository : IRepository<Ad_DocumentEntity, Guid>, IBaseExtensionRepository<Ad_DocumentEntity>
    {

    }
}
