using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.DictionaryType
{
    /// <summary>
    /// 数据字典类型
    /// </summary>
    [Table("Ad_Dictionary_Type")]
    [Comment("数据字典类型")]
    [Index(nameof(Code), Name = "IDX_Code")]
    public class Ad_DictionaryTypeEntity : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Comment("文章标题")]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Comment("编码")]
        [Column("Code", TypeName = "varchar(50)")]
        public string Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        [Column("Description", TypeName = "varchar(500)")]
        public string Description { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Comment("启用")]
        [Column("Enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        [Column("Sort", TypeName = "int")]
        public int Sort { get; set; }
    }
}