using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.BaseExtensions;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Paas.Pioneer.Admin.Core.Domain.Comment
{
    public interface ICommentRepository : IRepository<Information_CommentEntity, Guid>, IBaseExtensionRepository<Information_CommentEntity>
    {

    }
}
