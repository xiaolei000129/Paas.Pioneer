using System;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Login.Dtos
{
    public class LoginOutput
    {
        public Guid? TenantId { get; set; }

        public string RawData { get; set; }
    }
}