using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paas.Pioneer.Admin.Core.Domain.Shared.Enum
{
    /// <summary>
    /// 钱包明细类型
    /// </summary>
    public enum EWalletType
    {
        /// <summary>
        /// 微信充值
        /// </summary>
        [Description("微信充值")]
        WeChatRecharge = 1,
        /// <summary>
        /// 支付宝充值
        /// </summary>
        [Description("支付宝充值")]
        RechargeAlipay = 2,
        /// <summary>
        /// 提现
        /// </summary>
        [Description("提现")]
        Withdraw = 3,
        /// <summary>
        /// 任务获利(做完领取的任务)
        /// </summary>
        [Description("任务获利")]
        TaskProfit = 4,
        /// <summary>
        /// 支付领取任务（用户完成任务）
        /// </summary>
        [Description("支付领取任务")]
        ClaimTaskToPay = 5,
        /// <summary>
        /// 支付发布任务（余额支付提交的任务）
        /// </summary>
        [Description("支付发布任务")]
        TaskToPay = 6,
        /// <summary>
        /// 转账（用户向平台转账）
        /// </summary>
        [Description("转账")]
        Transfer = 7,
        /// <summary>
        /// 邀请获利
        /// </summary>
        [Description("邀请获利")]
        InviteProfit = 8,
        /// <summary>
        /// 购买曝光位
        /// </summary>
        [Description("购买曝光位")]
        Exposure = 9,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 10,
    }
}
