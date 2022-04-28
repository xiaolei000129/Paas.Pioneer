using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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

    /// <summary>
    /// 栅格管理类型
    /// </summary>
    public enum EGridType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        None = 0,

        /// <summary>
        /// 文章
        /// </summary>
        [Description("文章")]
        Article = 1,

        /// <summary>
        /// 小程序
        /// </summary>
        [Description("小程序")]
        MiniProgram = 2,

        /// <summary>
        /// 外链
        /// </summary>
        [Description("外链")]
        ExternalLink = 3
    }
}
