using Paas.Pioneer.Admin.Core.Domain.Shared.Enum;

namespace Paas.Pioneer.Admin.Core.Application.Contracts.LowCodeTableConfig.Dto.Output
{
    public class GenerateCodeLowCodeTableConfigOutPut
    {
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
        public bool ColumnKey { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// 列是否为空
        /// </summary>
        public bool IsColumnNullable { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public object DefaultValue { get; set; }

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
        /// 是否需要前端显示
        /// </summary>
        public bool WebShow { get; set; }

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
