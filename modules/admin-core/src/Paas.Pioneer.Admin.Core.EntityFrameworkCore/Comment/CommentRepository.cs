using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Comment;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.BaseExtensions;
using Paas.Pioneer.Admin.Core.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Admin.Core.EntityFrameworkCore.Comment
{
    public class EfCoreCommentRepository : BaseExtensionsRepository<Information_CommentEntity>, ICommentRepository
    {
        public EfCoreCommentRepository(IDbContextProvider<AdminsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

