using System.ComponentModel;

namespace Paas.Pioneer.Message.Domain.Shared.Enum
{
    /// <summary>
    /// 通知类型枚举
    /// </summary>
    [Description("通知类型枚举")]
    public enum ENotificationType
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = 10,

        /// <summary>
        /// 部分
        /// </summary>
        [Description("部分")]
        Part = 20,

        /// <summary>
        /// 指定
        /// </summary>
        [Description("指定")]
        Assign = 30
    }
}
