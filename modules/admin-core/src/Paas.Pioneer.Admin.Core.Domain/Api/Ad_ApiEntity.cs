using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Api
{
    /// <summary>
    /// 接口管理
    /// </summary>
    [Table("Ad_Api")]
    [Comment("接口管理")]
    [Index(nameof(ParentId), Name = "IDX_ParentId")]
    public class Ad_ApiEntity : BaseNotTenantEntity
    {
        /// <summary>
        /// 所属模块
        /// </summary>
        [Comment("所属模块")]
        [Column("ParentId", TypeName = "char(36)")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 接口命名
        /// </summary>
        [Comment("接口命名")]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        [Comment("接口名称")]
        [Column("Label", TypeName = "varchar(500)")]
        public string Label { get; set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        [Comment("接口地址")]
        [Column("Path", TypeName = "varchar(500)")]
        public string Path { get; set; }

        /// <summary>
        /// 接口提交方法
        /// </summary>
        [Comment("接口提交方法")]
        [Column("HttpMethods", TypeName = "varchar(50)")]
        public string HttpMethods { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        [Column("Sort", TypeName = "int")]
        public int Sort { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Comment("启用")]
        [Column("Enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 说明
        /// </summary>
        [Comment("说明")]
        [Column("Description", TypeName = "varchar(500)")]
        public string Description { get; set; }
    }
}