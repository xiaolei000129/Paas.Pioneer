using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 用户消息内容类型
    /// </summary>
    public enum EUserMessageContentType
    {
        /// <summary>
        /// 文字
        /// </summary>
        [Description("文字")]
        Text = 1,
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        Image = 2,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        Video = 3,
        /// <summary>
        /// 语音
        /// </summary>
        [Description("语音")]
        Voice = 4,
    }
}
