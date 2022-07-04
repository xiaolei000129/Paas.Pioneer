using Paas.Pioneer.WeChat.Domain.Shared.Common.WeChatApps;
using System;

namespace Paas.Pioneer.WeChat.Application.Contracts.WeChatApps.Dtos
{
    [Serializable]
    public class CreateUpdateWeChatAppDto
    {
        public WeChatAppType Type { get; set; }

        public Guid? WeChatComponentId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string OpenAppIdOrName { get; set; }

        public string AppId { get; set; }

        public string AppSecret { get; set; }

        public string Token { get; set; }

        public string EncodingAesKey { get; set; }
    }
}