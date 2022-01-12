using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.User
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("Ad_User")]
    [Comment("用户表")]
    public class Ad_UserEntity : BaseEntity
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Comment("账号")]
        [Column("UserName", TypeName = "varchar(50)")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Comment("密码")]
        [Column("Password", TypeName = "varchar(60)")]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Comment("昵称")]
        [Column("NickName", TypeName = "varchar(50)")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Comment("头像")]
        [Column("Avatar", TypeName = "varchar(500)")]
        public string Avatar { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Comment("启用")]
        [Column("Enabled")]
        [DefaultValue(true)]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        [Column("Remark", TypeName = "varchar(500)")]
        public string Remark { get; set; }

    }
}