using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Document
{
    /// <summary>
    /// 文档
    /// </summary>
    [Table("Ad_Document")]
    [Comment("文档表")]
    [Index(nameof(ParentId), Name = "IDX_ParentId")]
    public class Ad_DocumentEntity : BaseEntity
    {
        /// <summary>
        /// 父级节点
        /// </summary>
        [Comment("父级节点")]
        [Column("ParentId", TypeName = "char(36)")]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Comment("名称")]
        [Column("Label", TypeName = "varchar(50)")]
        public string Label { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Comment("类型")]
        [Column("Type", TypeName = "int")]
        public EDocumentType Type { get; set; }

        /// <summary>
        /// 命名
        /// </summary>
        [Comment("命名")]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Comment("内容")]
        [Column("Content", TypeName = "longtext")]
        public string Content { get; set; }

        /// <summary>
        /// Html
        /// </summary>
        [Comment("Html")]
        [Column("Html", TypeName = "longtext")]
        public string Html { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Comment("启用")]
        [Column("Enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 打开组
        /// </summary>
        [Comment("打开组")]
        [Column("Opened")]
        public bool? Opened { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        [Column("Sort", TypeName = "int")]
        public int Sort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        [Column("Description", TypeName = "varchar(500)")]
        public string Description { get; set; }
    }
}