using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.DocumentImage
{
    /// <summary>
    /// 文档图片
    /// </summary>
    [Table("Ad_Document_Image")]
    [Comment("文档图片表")]
    [Index(nameof(DocumentId), Name = "IDX_DocumentId")]
    public class Ad_DocumentImageEntity : BaseEntity
    {
        /// <summary>
        /// 文档Id
        /// </summary>
        [Comment("文档Id")]
        [Column("DocumentId", TypeName = "char(36)")]
        public Guid DocumentId { get; set; }

        /// <summary>
        /// 请求路径
        /// </summary>
        [Comment("文档Id")]
        public string Url { get; set; }
    }
}