using System.ComponentModel;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    public enum EAd_LowCodeTableConfigInputType
    {
        /// <summary>
        /// 输入框
        /// </summary>
        [Description("输入框")]
        Input = 1,

        /// <summary>
        /// 选择器
        /// </summary>
        [Description("选择器")]
        Select = 2,

        /// <summary>
        /// 单选框
        /// </summary>
        [Description("单选框")]
        Radio = 3,

        /// <summary>
        /// 多选框
        /// </summary>
        [Description("多选框")]
        Checkbox = 4,

        /// <summary>
        /// 计数器
        /// </summary>
        [Description("计数器")]
        InputNumber = 5,

        /// <summary>
        /// 开关
        /// </summary>
        [Description("开关")]
        Switch = 6,

        /// <summary>
        /// 日期选择器
        /// </summary>
        [Description("日期选择器")]
        DatePicker = 7,

        /// <summary>
        /// 上传
        /// </summary>
        [Description("上传")]
        Upload = 8,

        /// <summary>
        /// 多行文本框
        /// </summary>
        [Description("多行文本框")]
        Textarea = 9
    }
}
