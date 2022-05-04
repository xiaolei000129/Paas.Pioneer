using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;

namespace Paas.Pioneer.Admin.Core.Domain.Grid
{
    /// <summary>
    /// 栅格管理
    /// </summary>
    [Table("Information_Grid")]
    [Comment("栅格管理")]
    public class Information_GridEntity : BaseEntity
    {
        /// <summary>
        /// 字典Id
        /// </summary>
        [Comment("字典Id")]
        [Column("DictionaryId", TypeName = "char(36)")]
        public Guid DictionaryId { get; set; }

        /// <summary>
        /// 栅格管理类型
        /// </summary>
        [Comment("栅格管理类型")]
        [Column("GridType", TypeName = "int")]
        public EGridType GridType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Comment("名称")]
        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Comment("图片")]
        [Column("Portrait", TypeName = "varchar(200)")]
        public string Portrait { get; set; }

        /// <summary>
        /// 拓展信息（文章id、保存外部链接）
        /// </summary>
        [Comment("拓展信息")]
        [Column("Expand", TypeName = "varchar(200)")]
        public string Expand { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        [Column("Sort", TypeName = "int")]
        [DefaultValue(0)]
        public int Sort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        [Column("Description", TypeName = "varchar(100)")]
        public string Description { get; set; }
    }
}
