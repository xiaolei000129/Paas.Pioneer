using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Paas.Pioneer.Information.Domain.Shared.Enum;

namespace Paas.Pioneer.Information.Domain.Slideshow
{
    /// <summary>
    /// 轮播图管理
    /// </summary>
    [Table("Information_Slideshow")]
    [Comment("轮播图管理")]
    public class Information_SlideshowEntity : BaseEntity
    {
        /// <summary>
        /// 字典Id
        /// </summary>
        [Comment("字典Id")]
        [Column("DictionaryId", TypeName = "char(36)")]
        public Guid DictionaryId { get; set; }

        /// <summary>
        /// 轮播图类型
        /// </summary>
        [Comment("轮播图类型")]
        [Column("SlideshowType", TypeName = "int")]
        public ESlideshowType SlideshowType { get; set; }

        /// <summary>
        /// 拓展信息（文章id、保存外部链接）
        /// </summary>
        [Comment("拓展信息")]
        [Column("Expand", TypeName = "varchar(200)")]
        public string Expand { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Comment("标题")]
        [Column("Title", TypeName = "varchar(100)")]
        public string Title { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Comment("图片")]
        [Column("Portrait", TypeName = "varchar(200)")]
        public string Portrait { get; set; }

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
