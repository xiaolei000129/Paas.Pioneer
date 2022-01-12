using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Input
{

    public class AddLowCodeTableConfigInput
    {
        /// <summary>
        /// LowCodeTableId，父Id
        /// </summary>
        public Guid LowCodeTableId { get; set; }

        /// <summary>
        /// 所在表
        /// </summary>
        public string LowCodeTableName { get; set; }

        /// <summary>
        /// 属性,字段名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 是否为可空类型
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 是否需要前端添加
        /// </summary>
        public bool WebAdd { get; set; }

        /// <summary>
        /// 是否需要前端修改
        /// </summary>
        public bool WebUpdate { get; set; }

        /// <summary>
        /// 是否需要前端查询
        /// </summary>
        public bool WebSelect { get; set; }

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
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
