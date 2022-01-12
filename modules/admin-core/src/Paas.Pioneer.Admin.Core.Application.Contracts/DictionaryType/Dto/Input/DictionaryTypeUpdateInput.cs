using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.DictionaryType.Dto.Input
{
    /// <summary>
    /// 修改
    /// </summary>
    public class DictionaryTypeUpdateInput
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
		public bool Enabled { get; set; }
    }
}