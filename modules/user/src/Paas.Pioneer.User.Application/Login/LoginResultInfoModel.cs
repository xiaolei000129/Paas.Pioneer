using System;
using EasyAbp.Abp.WeChat.MiniProgram.Services.Login;
using EasyAbp.WeChatManagement.Common.WeChatApps;

namespace Paas.Pioneer.User.Application.Login
{
    public record LoginResultInfoModel
    {
        public WeChatApp MiniProgram { get; init; }

        public string LoginProvider { get; init; }

        public string ProviderKey { get; init; }

        public string UnionId { get; init; }

        public Code2SessionResponse Code2SessionResponse { get; init; }
    }
}