using Paas.Pioneer.SignalR.Model;

namespace Paas.Pioneer.SignalR
{
    /// <summary>
    /// 接口限制
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <returns></returns>
        Task Send(MessageModel model);
    }
}
