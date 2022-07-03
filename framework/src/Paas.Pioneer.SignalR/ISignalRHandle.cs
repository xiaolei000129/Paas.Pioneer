using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Paas.Pioneer.SignalR
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public interface ISignalRHandle
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MessageType { get; }

        /// <summary>
        /// 对比消息类型
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public bool EqualMessageType([NotNull] string messageType) => this.MessageType == messageType;

        /// <summary>
        /// 方法处理
        /// </summary>
        /// <param name="messageData"></param>
        public Task HandleAsync(object messageData);
    }
}
