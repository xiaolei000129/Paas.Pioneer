using System.ComponentModel;

namespace Paas.Pioneer.Information.Domain.Shared.Enum
{
    /// <summary>
    /// 轮播图类型
    /// </summary>
    public enum ESlideshowType
    {
        /// <summary>
        /// 文章
        /// </summary>
        [Description("文章")]
        Article = 1,
        /// <summary>
        /// 视图跳转
        /// </summary>
        [Description("视图跳转")]
        View = 2,

        /// <summary>
        /// 链接跳转
        /// </summary>
        [Description("链接跳转")]
        Like = 3
    }
}
