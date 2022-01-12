using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.LowCodeTable
{
    /// <summary>
    /// 低代码表格
    /// </summary>
    [Comment("低代码表格")]
    [Table("Ad_LowCodeTable")]
    public class Ad_LowCodeTableEntity : BaseEntityNotTenantCore
    {
        /// <summary>
        /// 所属节点（菜单父级Id）
        /// </summary>
        [Comment("所属节点（菜单父级Id）")]
        [Column("MenuParentId", TypeName = "char(36)")]
        public Guid? MenuParentId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Comment("菜单名称")]
        [Column("MenuName", TypeName = "varchar(50)")]
        public string MenuName { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Comment("表名")]
        [Column("LowCodeTableName", TypeName = "varchar(50)")]
        public string LowCodeTableName { get; set; }

        /// <summary>
        /// 代码类名
        /// </summary>
        [Comment("代码类名")]
        [Column("Taxon", TypeName = "varchar(50)")]
        public string Taxon { get; set; }

        /// <summary>
        /// 所属功能模块（业务场景）
        /// </summary>
        [Comment("所属功能模块（业务场景）")]
        [Column("FunctionModule", TypeName = "varchar(100)")]
        public string FunctionModule { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        [Column("Description", TypeName = "varchar(500)")]
        public string Description { get; set; }
    }
}