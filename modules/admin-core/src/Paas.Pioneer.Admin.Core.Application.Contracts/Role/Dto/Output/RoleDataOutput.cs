using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Output
{
    /// <summary>
    /// 角色导出
    /// </summary>
    public partial class RoleDataOutput
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
		public bool Enabled { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
		public int Sort { get; set; }
    }
}