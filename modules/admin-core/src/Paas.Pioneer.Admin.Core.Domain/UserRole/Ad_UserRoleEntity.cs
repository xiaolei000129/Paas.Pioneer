using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.UserRole
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [Table("Ad_User_Role")]
    [Comment("用户角色表")]
    [Index(nameof(UserId), Name = "IDX_UserId")]
    [Index(nameof(RoleId), Name = "IDX_RoleId")]
    public class Ad_UserRoleEntity : BaseEntityNotTenantCore
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Comment("用户Id")]
        [Column("UserId", TypeName = "char(36)")]
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Comment("角色Id")]
        [Column("RoleId", TypeName = "char(36)")]
        public Guid RoleId { get; set; }

    }
}
