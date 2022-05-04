using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using System;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Comment
{
    public interface ICommentRepository : IRepository<Information_CommentEntity, Guid>, IBaseExtensionRepository<Information_CommentEntity>
    {

    }
}
