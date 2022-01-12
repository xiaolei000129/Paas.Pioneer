using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Personnel.Position
{
    /// <summary>
    /// 职位
    /// </summary>
	[Table("Pe_Position")]
    [Comment("职位表")]
    public class Pe_PositionEntity : BaseEntity
    {

        public Pe_PositionEntity() { }
        public Pe_PositionEntity(Guid id)
        {
            this.Id = id;
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Comment("名称")]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Comment("编码")]
        [Column("Code", TypeName = "varchar(50)")]
        public string Code { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Comment("说明")]
        [Column("Description", TypeName = "varchar(200)")]
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