using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Permission
{
    /// <summary>
    /// 权限
    /// </summary>
    [Table("Ad_Permission")]
    [Comment("权限表")]
    [Index(nameof(ParentId), Name = "IDX_ParentId")]
    public class Ad_PermissionEntity : BaseNotTenantEntity
    {
        public Ad_PermissionEntity()
        {

        }

        public Ad_PermissionEntity(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// 父级节点
        /// </summary>
        [Comment("父级节点")]
        [Column("ParentId", TypeName = "char(36)")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        [Comment("权限名称")]
        [Column("Label", TypeName = "varchar(50)")]
        public string Label { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        [Comment("权限编码")]
        [Column("Code", TypeName = "varchar(50)")]
        public string Code { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        [Comment("权限类型")]
        [Column("Type", TypeName = "int")]
        public EPermissionType Type { get; set; }

        /// <summary>
        /// 视图
        /// </summary>
        [Comment("视图")]
        [Column("ViewId", TypeName = "char(36)")]
        public Guid? ViewId { get; set; }

        /// <summary>
        /// 菜单访问地址
        /// </summary>
        [Comment("菜单访问地址")]
        [Column("Path", TypeName = "varchar(50)")]
        public string Path { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Comment("图标")]
        [Column("Icon", TypeName = "varchar(50)")]
        public string Icon { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        [Comment("隐藏")]
        [Column("Hidden")]
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// 启用
        /// </summary>
        [Comment("启用")]
        [Column("Enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 可关闭
        /// </summary>
        [Comment("可关闭")]
        [Column("Closable")]
        public bool Closable { get; set; }

        /// <summary>
        /// 打开组
        /// </summary>
        [Comment("打开组")]
        [Column("Opened")]
        public bool Opened { get; set; }

        /// <summary>
        /// 打开新窗口
        /// </summary>
        [Comment("打开新窗口")]
        [Column("NewWindow")]
        public bool NewWindow { get; set; }

        /// <summary>
        /// 链接外显
        /// </summary>
        [Comment("链接外显")]
        [Column("External")]
        public bool External { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        [Column("Sort", TypeName = "int")]
        public int Sort { get; set; } = 0;

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        [Column("Description", TypeName = "varchar(100)")]
        public string Description { get; set; }
    }
}