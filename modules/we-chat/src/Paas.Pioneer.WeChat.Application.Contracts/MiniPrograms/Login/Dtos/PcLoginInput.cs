using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Login.Dtos
{
    [Serializable]
    public class PcLoginInput
    {
        [Required]
        public string Token { get; set; }
    }
}