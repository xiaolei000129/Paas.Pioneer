using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Comment
{
    /// <summary>
    /// 评论表
    /// </summary>
    [Table("Information_Comment")]
    [Comment("评论表")]
    [Index(nameof(BusinessId), Name = "IDX_BusinessId")]
    [Index(nameof(ParentId), Name = "IDX_ParentId")]
    public class Information_CommentEntity : BaseEntity
    {
        /// <summary>
        /// 业务Id
        /// </summary>
        [Comment("业务Id")]
        [Column("BusinessId", TypeName = "char(36)")]
        public Guid BusinessId { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        [Comment("父级Id")]
        [Column("ParentId", TypeName = "char(36)")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 评论详情
        /// </summary>
        [Comment("评论详情")]
        [Column("Details", TypeName = "varchar(500)")]
        public string Details { get; set; }
    }
}
