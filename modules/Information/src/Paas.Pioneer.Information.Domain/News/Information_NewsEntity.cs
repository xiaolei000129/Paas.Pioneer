using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Paas.Pioneer.Information.Domain.News
{
    /// <summary>
    /// 新闻表管理
    /// </summary>
    [Table("Information_News")]
    [Comment("新闻表管理")]
    public class Information_NewsEntity : BaseEntity
    {
        /// <summary>
        /// 字典Id
        /// </summary>
        [Comment("字典Id")]
        [Column("DictionaryId", TypeName = "char(36)")]
        public Guid DictionaryId { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Comment("图片")]
        [Column("Portrait", TypeName = "varchar(200)")]
        public string Portrait { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [Comment("发布时间")]
        [Column("PushTime", TypeName = "datetime")]
        public DateTime PushTime { get; set; }

        /// <summary>
        /// 新闻内容
        /// </summary>
        [Comment("新闻内容")]
        [Column("NewsContent", TypeName = "text")]
        public string NewsContent { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        [Comment("隐藏")]
        [Column("IsHidden")]
        [DefaultValue(false)]
        public bool Hidden { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Comment("启用")]
        [Column("IsEnabled")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }

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
