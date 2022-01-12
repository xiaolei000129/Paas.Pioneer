using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.LowCodeTableConfig
{
    [Comment("低代码表格配置")]
    [Table("Ad_LowCodeTableConfig")]
    [Index(nameof(LowCodeTableId), Name = "IDX_LowCodeTableId")]
    public class Ad_LowCodeTableConfigEntity : BaseEntityNotTenantCore
    {
        /// <summary>
        /// LowCodeTableId，父Id
        /// </summary>
        [Comment("LowCodeTableId,父Id")]
        [Column("LowCodeTableId", TypeName = "char(36)")]
        public Guid LowCodeTableId { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        [Comment("字段名")]
        [Column("ColumnName", TypeName = "varchar(50)")]
        public string ColumnName { get; set; }

        /// <summary>
        /// 是否为可空类型
        /// </summary>
        [Comment("是否为可空类型")]
        [Column("IsNullable")]
        public bool IsNullable { get; set; }

        /// <summary>
        /// 是否需要前端添加
        /// </summary>
        [Comment("是否需要前端添加")]
        [Column("IsWebAdd")]
        public bool IsWebAdd { get; set; }

        /// <summary>
        /// 是否需要前端修改
        /// </summary>
        [Comment("是否需要前端修改")]
        [Column("IsWebUpdate")]
        public bool IsWebUpdate { get; set; }

        /// <summary>
        /// 是否需要前端查询
        /// </summary>
        [Comment("是否需要前端查询")]
        [Column("IsWebSelect")]
        public bool IsWebSelect { get; set; }

        /// <summary>
        /// 是否需要前端显示
        /// </summary>
        [Comment("是否需要前端显示")]
        [Column("IsWebShow")]
        public bool IsWebShow { get; set; }

        /// <summary>
        /// 查询方式
        /// </summary>
        [Comment("查询方式")]
        [Column("QueryType", TypeName = "int")]
        public EAd_LowCodeTableConfigQueryType QueryType { get; set; }

        /// <summary>
        /// 输入类型
        /// </summary>
        [Comment("输入类型")]
        [Column("InputType", TypeName = "int")]
        public EAd_LowCodeTableConfigInputType InputType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        [Column("Description", TypeName = "varchar(500)")]
        public string Description { get; set; }
    }
}
