using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;

namespace Paas.Pioneer.Information.Application.Contracts.Comment.Dto.Output
{
    /// <summary>
    /// 获取评论管理分页
    /// </summary>
    public class GetCommentPageListOutput
    {

        /// <summary>
        /// 业务Id
        /// </summary>
        public Guid BusinessId { get; set; }


        /// <summary>
        /// 父级Id
        /// </summary>
        public Guid ParentId { get; set; }


        /// <summary>
        /// 评论详情
        /// </summary>
        public string Details { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

    }
}