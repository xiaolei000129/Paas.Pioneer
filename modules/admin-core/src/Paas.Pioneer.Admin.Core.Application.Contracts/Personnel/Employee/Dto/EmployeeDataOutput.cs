using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Personnel.Employee.Dto
{
    /// <summary>
    /// 员工数据导出
    /// </summary>
    public partial class EmployeeDataOutput
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public ESex Sex { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 主属部门Id
        /// </summary>
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// 主管Id
        /// </summary>
        public Guid? PrimaryEmployeeId { get; set; }

        /// <summary>
        /// 职位Id
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime HireDate { get; set; }

    }
}