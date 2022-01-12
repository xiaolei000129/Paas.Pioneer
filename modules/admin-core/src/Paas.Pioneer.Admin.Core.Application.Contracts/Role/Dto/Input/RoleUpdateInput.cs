using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.Role.Dto.Input
{
    /// <summary>
    /// 修改
    /// </summary>
    public partial class RoleUpdateInput
    {
        /// <summary>
        /// 接口Id
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
    }
}