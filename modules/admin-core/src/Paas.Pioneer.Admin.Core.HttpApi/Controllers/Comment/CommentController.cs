using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Admin.Core.Application.Contracts.Comment;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Admin.Core.HttpApi.Controllers
{
    /// <summary>
    /// 评论管理
    /// </summary>
    [Route("api/admin/[controller]/[action]")]
    [Authorize]
    public class CommentController : AbpController
    {
        
        private readonly ICommentService _commentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// 查询评论管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<GetCommentOutput>> Get(Guid id)
        {
            return await _commentService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseOutput<Page<GetCommentPageListOutput>>> GetPageList(PageInput<GetCommentPageListInput> input)
        {
            return await _commentService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> Add([FromBody] AddCommentInput input)
        {
            return await _commentService.AddAsync(input);
        }

        /// <summary>
        /// 修改评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResponseOutput> Update([FromBody] UpdateCommentInput input)
        {
            return await _commentService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除评论管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IResponseOutput> Delete(Guid id)
        {
            return await _commentService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除评论管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> BatchSoftDelete([FromBody] Guid[] ids)
        {
            return await _commentService.BatchSoftDeleteAsync(ids);
        }
    }
}