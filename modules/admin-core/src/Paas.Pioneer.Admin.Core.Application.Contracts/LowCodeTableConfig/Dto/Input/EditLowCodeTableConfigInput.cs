using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input
{

    public class EditLowCodeTableConfigInput
    {
        /// <summary>
        /// LowCodeTableId，父Id
        /// </summary>
        public Guid LowCodeTableId { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 是否为可空类型
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 是否需要前端添加
        /// </summary>
        public bool IsWebAdd { get; set; }

        /// <summary>
        /// 是否需要前端修改
        /// </summary>
        public bool IsWebUpdate { get; set; }

        /// <summary>
        /// 是否需要前端查询
        /// </summary>
        public bool IsWebSelect { get; set; }

        /// <summary>
        /// 是否需要前端显示
        /// </summary>
        public bool IsWebShow { get; set; }

        /// <summary>
        /// 查询方式
        /// </summary>
        public EAd_LowCodeTableConfigQueryType QueryType { get; set; }

        /// <summary>
        /// 输入类型
        /// </summary>
        public EAd_LowCodeTableConfigInputType InputType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
