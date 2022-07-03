using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Paas.Pioneer.SignalR.Model;
using Volo.Abp.AspNetCore.SignalR;
using System.Text.Json;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Paas.Pioneer.SignalR
{
    /// <summary>
    /// 聊天控制中心
    /// </summary>
    [Authorize]
    [HubRoute("/chat-hub")]
    public class ChatHub : AbpHub<IChatClient>, IChatClient
    {
        private readonly IEnumerable<ISignalRHandle> _signalRHandles;
        private readonly ILogger<ChatHub> _logger;
        public ChatHub(IEnumerable<ISignalRHandle> signalRHandles,
            ILogger<ChatHub> logger)
        {
            this._signalRHandles = signalRHandles;
            this._logger = logger;
        }

        /// <summary>
        /// 建立连接
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// 销毁连接
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="model">消息数据包</param>
        /// <returns></returns>
        public async Task Send(MessageModel model)
        {
            if (model == null && model.MessageType.IsNullOrEmpty())
            {
                _logger.LogWarning($"ChatHub=》Send消息类型错误；消息类型：{model.MessageType} 消息数据：{JsonSerializer.Serialize(model.Data)}");
                return;
            }
            if (!_signalRHandles.Any())
            {
                _logger.LogError($"ChatHub=》Send系统错误未进行注入实现；消息类型：{model.MessageType} 消息数据：{JsonSerializer.Serialize(model.Data)}");
                return;
            }
            await _signalRHandles.FirstOrDefault(x => x.EqualMessageType(model.MessageType)).HandleAsync(model);
        }
    }
}
