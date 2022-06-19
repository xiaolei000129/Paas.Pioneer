namespace Paas.Pioneer.SignalR.Model
{
    public class MessageModel
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// 消息数据
        /// </summary>
        public object Data { get; set; }
    }
}
