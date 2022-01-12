using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 平台类型
    /// </summary>
    public enum EPlatgormWalletType
    {
        /// <summary>
        /// 微信收入
        /// </summary>
        [Description("微信收入")]
        WeChatRevenue = 1,
        /// <summary>
        /// 支付宝收入
        /// </summary>
        [Description("支付宝收入")]
        AlipayRevenue = 2,
        /// <summary>
        /// 提现支出
        /// </summary>
        [Description("提现支出")]
        WithdrawExpenditure = 3,
        /// <summary>
        /// 转账收入（用户向平台转账）
        /// </summary>
        [Description("转账收入")]
        TransferRevenue = 4,
        /// <summary>
        /// 手续费收入
        /// </summary>
        [Description("手续费收入")]
        HandlingFeeRevenue = 5,
        /// <summary>
        /// 曝光位收入
        /// </summary>
        [Description("曝光位收入")]
        ExposureRevenue = 6,
        /// <summary>
        /// 邀请好友，支出用户
        /// </summary>
        [Description("邀请支出")]
        InviteProfit = 7
    }
}
