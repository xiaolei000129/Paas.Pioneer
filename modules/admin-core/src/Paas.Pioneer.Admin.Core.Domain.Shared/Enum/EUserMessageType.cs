using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 用户消息类型
    /// </summary>
    public enum EUserMessageType
    {
        /// <summary>
        /// 个人通知
        /// </summary>
        [Description("个人通知")]
        PersonalNotice = 1,
        /// <summary>
        /// 全站通知
        /// </summary>
        [Description("全站通知")]
        SitewideNotification = 2,
    }
}
