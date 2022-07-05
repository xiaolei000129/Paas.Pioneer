using System;

namespace Paas.Pioneer.User.Application.Contracts.Login.Dtos
{
    [Serializable]
    public class GetPcLoginACodeOutput
    {
        public string HandlePage { get; set; }

        public string Token { get; set; }

        public byte[] ACode { get; set; }
    }
}