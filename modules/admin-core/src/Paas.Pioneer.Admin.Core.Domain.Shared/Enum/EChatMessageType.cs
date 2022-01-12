using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 信息类型
    /// </summary>
    public enum EChatMessageType
    {
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        Picture = 1,

        /// <summary>
        /// 语音
        /// </summary>
        [Description("语音")]
        Voice = 2,

        /// <summary>
        /// 文字
        /// </summary>
        [Description("文字")]
        Text = 3,
    }
}
