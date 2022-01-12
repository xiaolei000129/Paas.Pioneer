using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Personnel.Organization
{
    /// <summary>
    /// 组织架构
    /// </summary>
	[Table("Pe_Organization")]
    [Comment("组织架构表")]
    [Index(nameof(PrimaryEmployeeId), Name = "IDX_PrimaryEmployeeId")]
    [Index(nameof(ParentId), Name = "IDX_ParentId")]
    public class Pe_OrganizationEntity : BaseEntity
    {
        public Pe_OrganizationEntity() { }
        public Pe_OrganizationEntity(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// 父级
        /// </summary>
        [Comment("父级")]
        [Column("ParentId", TypeName = "char(36)")]
        public Guid ParentId { get; set; }

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
        /// 值
        /// </summary>
        [Comment("值")]
        [Column("Value", TypeName = "varchar(50)")]
        public string Value { get; set; }

        /// <summary>
        /// 主管Id
        /// </summary>
        [Comment("主管Id")]
        [Column("PrimaryEmployeeId", TypeName = "char(36)")]
        public Guid? PrimaryEmployeeId { get; set; }

        /// <summary>
        /// 员工人数
        /// </summary>
        [Comment("员工人数")]
        [Column("EmployeeCount", TypeName = "int")]
        public int EmployeeCount { get; set; }

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