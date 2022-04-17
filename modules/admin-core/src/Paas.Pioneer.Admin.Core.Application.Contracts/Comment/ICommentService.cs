using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Comment
{
    /// <summary>
    /// 评论管理接口
    /// </summary>
    public interface ICommentService : IApplicationService
    {
        /// <summary>
        /// 查询评论管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<ResponseOutput<GetCommentOutput>> GetAsync(Guid id);

        /// <summary>
        /// 查询分页评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<GetCommentPageListOutput>>> GetPageListAsync(PageInput<GetCommentPageListInput> model);

        /// <summary>
        /// 新增评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> AddAsync(AddCommentInput input);

        /// <summary>
        /// 修改评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IResponseOutput> UpdateAsync(UpdateCommentInput input);

        /// <summary>
        /// 删除评论管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<IResponseOutput> DeleteAsync(Guid id);
        
        /// <summary>
        /// 批量删除评论管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids);
    }
}