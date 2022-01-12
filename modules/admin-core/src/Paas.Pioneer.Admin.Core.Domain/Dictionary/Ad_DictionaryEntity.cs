using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Dictionary
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Comment("数据字典")]
    [Table("Ad_Dictionary")]
    [Index(nameof(DictionaryTypeId), Name = "IDX_DictionaryTypeId")]
    [Index(nameof(Code), Name = "IDX_Code")]
    public class Ad_DictionaryEntity : BaseEntity
    {

        /// <summary>
        /// 字典类型Id
        /// </summary>
        [Comment("字典类型Id")]
        [Column("DictionaryTypeId", TypeName = "char(36)")]
        public Guid DictionaryTypeId { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        [Comment("文章标题")]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        [Comment("字典编码")]
        [Column("Code", TypeName = "varchar(50)")]
        public string Code { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        [Comment("字典值")]
        [Column("Value", TypeName = "varchar(50)")]
        public string Value { get; set; }

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