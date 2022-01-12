using Microsoft.EntityFrameworkCore;
using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using Paas.Pioneer.Domain;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paas.Pioneer.Admin.Core.Domain.Personnel.Employee
{
    /// <summary>
    /// 员工
    /// </summary>
    [Table("Pe_Employee")]
    [Comment("员工表")]
    [Index(nameof(UserId), Name = "IDX_UserId")]
    [Index(nameof(OrganizationId), Name = "IDX_OrganizationId")]
    [Index(nameof(PrimaryEmployeeId), Name = "IDX_PrimaryEmployeeId")]
    [Index(nameof(PositionId), Name = "IDX_PositionId")]
    public class Pe_EmployeeEntity : BaseEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Comment("用户Id")]
        [Column("UserId", TypeName = "char(36)")]
        public Guid UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Comment("姓名")]
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Comment("昵称")]
        [Column("NickName", TypeName = "varchar(50)")]
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Comment("性别")]
        [Column("Sex", TypeName = "int")]
        public ESex Sex { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [Comment("工号")]
        [Column("Code", TypeName = "varchar(50)")]
        public string Code { get; set; }

        /// <summary>
        /// 主属部门Id
        /// </summary>
        [Comment("主属部门Id")]
        [Column("OrganizationId", TypeName = "char(36)")]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// 主管Id
        /// </summary>
        [Comment("主管Id")]
        [Column("PrimaryEmployeeId", TypeName = "char(36)")]
        public Guid? PrimaryEmployeeId { get; set; }

        /// <summary>
        /// 职位Id
        /// </summary>
        [Comment("职位Id")]
        [Column("PositionId", TypeName = "char(36)")]
        public Guid PositionId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Comment("手机号")]
        [Column("Phone", TypeName = "varchar(20)")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Comment("邮箱")]
        [Column("Email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        [Comment("入职时间")]
        [Column("EntryTime", TypeName = "datetime")]
        public DateTime? EntryTime { get; set; }
    }
}