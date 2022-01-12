using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;
using System;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTable.Dto.Output
{
    /// <summary>
    /// 数据库表列
    /// </summary>
    public class LowCodeTableColumnOutput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// LowCodeTableId，父Id
        /// </summary>
        public Guid LowCodeTableId { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 数据库中类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// .NET字段类型
        /// </summary>
        public string NetType { get; set; }

        /// <summary>
        /// 字段描述
        /// </summary>
        public string ColumnComment { get; set; }

        /// <summary>
        /// 主外键
        /// </summary>
        public string ColumnKey { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public object MaxLength { get; set; }

        /// <summary>
        /// 列是否为空
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public object DefaultValue { get; set; }

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
        public EAd_LowCodeTableConfigQueryType QueryType { get; set; } = EAd_LowCodeTableConfigQueryType.input;

        /// <summary>
        /// 输入类型
        /// </summary>
        public EAd_LowCodeTableConfigInputType InputType { get; set; } = EAd_LowCodeTableConfigInputType.Input;
    }
}
