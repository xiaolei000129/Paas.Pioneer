using Paas.Pioneer.Admin.Core.Application.Contracts.Comment;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Admin.Core.Domain.Comment;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.Application.Comment
{
    /// <summary>
    /// 评论管理服务
    /// </summary>
    public class CommentService : ApplicationService, ICommentService
    {
        
        private readonly ICommentRepository _commentRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        /// <summary>
        /// 查询评论管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<ResponseOutput<GetCommentOutput>> GetAsync(Guid id)
        {
            var result = await _commentRepository.GetAsync(p=>p.Id == id, x => new GetCommentOutput()
            {
                BusinessId = x.BusinessId,
                ParentId = x.ParentId,
                Details = x.Details,
                LastModificationTime = x.LastModificationTime,
                CreationTime = x.CreationTime,
                Id = x.Id,
            });
            return ResponseOutput.Succees(result);
        }

        /// <summary>
        /// 查询分页评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<GetCommentPageListOutput>>> GetPageListAsync(PageInput<GetCommentPageListInput> input)
        {
            var data = await _commentRepository.GetResponseOutputPageListAsync(x => new GetCommentPageListOutput
            {
                BusinessId = x.BusinessId,
                ParentId = x.ParentId,
                Details = x.Details,
                LastModificationTime = x.LastModificationTime,
                CreationTime = x.CreationTime,
                Id = x.Id,
            }, input: input);
            return data;
        }

        /// <summary>
        /// 新增评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> AddAsync(AddCommentInput input)
        {
            var comment = ObjectMapper.Map<AddCommentInput, Information_CommentEntity>(input);
            await _commentRepository.InsertAsync(comment);
            return ResponseOutput.Succees("添加成功！");
        }

        /// <summary>
        /// 修改评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<IResponseOutput> UpdateAsync(UpdateCommentInput input)
        {
            var entity = await _commentRepository.GetAsync(input.Id);
            if (entity?.Id == Guid.Empty)
            {
                throw new BusinessException("数据不存在！");
            }
            ObjectMapper.Map(input, entity);
            await _commentRepository.UpdateAsync(entity);
            return ResponseOutput.Succees("修改成功！");
        }

        /// <summary>
        /// 删除评论管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<IResponseOutput> DeleteAsync(Guid id)
        {
            await _commentRepository.DeleteAsync(m => m.Id == id);
            return ResponseOutput.Succees("删除成功！");
        }

        /// <summary>
        /// 批量删除评论管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        public async Task<IResponseOutput> BatchSoftDeleteAsync(IEnumerable<Guid> ids)
        {
            await _commentRepository.DeleteAsync(x => ids.Contains(x.Id));
            return ResponseOutput.Succees("删除成功！");
        }
    }
}