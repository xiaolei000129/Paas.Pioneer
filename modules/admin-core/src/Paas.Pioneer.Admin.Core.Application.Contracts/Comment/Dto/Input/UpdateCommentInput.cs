using System;
using Paas.Pioneer.Domain.Shared.ModelValidation;
using System.ComponentModel.DataAnnotations;
namespace Paas.Pioneer.Admin.Core.Application.Contracts.Comment.Dto.Input
{
    /// <summary>
    /// 评论管理修改
    /// </summary>
    public class UpdateCommentInput
    {

        /// <summary>
        /// 业务Id
        /// </summary>
        [Required(ErrorMessage = "请输入业务Id")]
        public Guid BusinessId { get; set; }


        /// <summary>
        /// 父级Id
        /// </summary>
        [Required(ErrorMessage = "请输入父级Id")]
        public Guid ParentId { get; set; }


        /// <summary>
        /// 评论详情
        /// </summary>
        [Required(ErrorMessage = "请输入评论详情")]
        public string Details { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        [Required(ErrorMessage = "请输入修改时间")]
        public DateTime? LastModificationTime { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "请输入创建时间")]
        public DateTime CreationTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [NotEqual("00000000-0000-0000-0000-000000000000", ErrorMessage = "请输入")]
        [Required(ErrorMessage = "请输入")]
        public Guid Id { get; set; }

    }
}