using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.View
{
    /// <summary>
    /// 视图管理
    /// </summary>
    [Table("Ad_View")]
    [Comment("视图管理表")]
    [Index(nameof(ParentId), Name = "IDX_ParentId")]
    public class Ad_ViewEntity : BaseNotTenantEntity
    {
        /// <summary>
        /// 所属节点
        /// </summary>
        [Comment("所属节点")]
        [Column("ParentId", TypeName = "char(36)")]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 视图命名
        /// </summary>
        [Comment("视图命名")]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 视图名称
        /// </summary>
        [Comment("视图名称")]
        [Column("Label", TypeName = "varchar(50)")]
        public string Label { get; set; }

        /// <summary>
        /// 视图路径
        /// </summary>
        [Comment("视图路径")]
        [Column("Path", TypeName = "varchar(250)")]
        public string Path { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Comment("说明")]
        [Column("Description", TypeName = "varchar(500)")]
        public string Description { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Comment("启用")]
        [Column("Enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 缓存
        /// </summary>
        [Comment("缓存")]
        [Column("Cache")]
        public bool Cache { get; set; } = true;

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        [Column("Sort", TypeName = "int")]
        public int Sort { get; set; }
    }
}