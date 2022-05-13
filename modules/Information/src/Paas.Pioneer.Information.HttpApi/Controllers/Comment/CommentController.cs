using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Comment.Dto.Input;
using Paas.Pioneer.Information.Application.Contracts.Comment.Dto.Output;
using Paas.Pioneer.Information.Application.Contracts.Comment;

namespace Paas.Pioneer.Information.HttpApi.Controllers.Comment
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
        public async Task<GetCommentOutput> Get(Guid id)
        {
            return await _commentService.GetAsync(id);
        }

        /// <summary>
        /// 查询分页评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Page<GetCommentPageListOutput>> GetPageList([FromBody] PageInput<GetCommentPageListInput> input)
        {
            return await _commentService.GetPageListAsync(input);
        }

        /// <summary>
        /// 新增评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add([FromBody] AddCommentInput input)
        {
            await _commentService.AddAsync(input);
        }

        /// <summary>
        /// 修改评论管理
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] UpdateCommentInput input)
        {
            await _commentService.UpdateAsync(input);
        }

        /// <summary>
        /// 删除评论管理
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task SoftDelete(Guid id)
        {
            await _commentService.DeleteAsync(id);
        }

        /// <summary>
        /// 批量删除评论管理
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost]
        public async Task BatchSoftDelete([FromBody] Guid[] ids)
        {
            await _commentService.BatchSoftDeleteAsync(ids);
        }
    }
}