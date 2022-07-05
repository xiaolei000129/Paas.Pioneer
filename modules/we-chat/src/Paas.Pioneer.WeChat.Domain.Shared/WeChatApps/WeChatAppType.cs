using System.ComponentModel;

namespace Paas.Pioneer.WeChat.Domain.Shared.WeChatApps
{
    public enum WeChatAppType
    {
        /// <summary>
        /// 小程序
        /// </summary>
        [Description("小程序")]
        MiniProgram = 10,

        /// <summary>
        /// 公众号
        /// </summary>
        [Description("公众号")]
        Official = 20,

        /// <summary>
        /// 文档
        /// </summary>
        [Description("文档")]
        Work = 30,

        /// <summary>
        /// 开发平台
        /// </summary>
        [Description("开发平台")]
        OpenPlatform = 40
    }
}