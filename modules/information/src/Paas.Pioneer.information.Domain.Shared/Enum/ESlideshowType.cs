using System.ComponentModel;

namespace Paas.Pioneer.Information.Domain.Shared.Enum
{
    /// <summary>
    /// 轮播图类型
    /// </summary>
    public enum ESlideshowType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        None = 0,

        /// <summary>
        /// 文章
        /// </summary>
        [Description("文章")]
        Article = 1,

        /// <summary>
        /// 小程序
        /// </summary>
        [Description("小程序")]
        MiniProgram = 2,

        /// <summary>
        /// 外链
        /// </summary>
        [Description("外链")]
        ExternalLink = 3
    }
}
