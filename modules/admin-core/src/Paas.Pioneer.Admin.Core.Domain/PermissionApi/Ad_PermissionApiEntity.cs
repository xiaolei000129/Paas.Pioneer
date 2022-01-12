using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.PermissionApi
{
    /// <summary>
    /// 权限接口
    /// </summary>
    [Table("Ad_Permission_Api")]
    [Comment("权限接口表")]
    [Index(nameof(PermissionId), Name = "IDX_PermissionId")]
    [Index(nameof(ApiId), Name = "IDX_ApiId")]
    public class Ad_PermissionApiEntity : BaseEntityNotTenantCore
    {
        /// <summary>
        /// 权限Id
        /// </summary>
        [Comment("权限Id")]
        [Column("PermissionId", TypeName = "char(36)")]
        public Guid PermissionId { get; set; }

        /// <summary>
        /// 接口Id
        /// </summary>
        [Comment("接口Id")]
        [Column("ApiId", TypeName = "char(36)")]
        public Guid ApiId { get; set; }
    }
}
