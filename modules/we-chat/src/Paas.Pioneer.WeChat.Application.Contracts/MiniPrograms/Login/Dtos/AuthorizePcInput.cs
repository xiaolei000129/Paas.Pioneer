using System;
using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Login.Dtos
{
    [Serializable]
    public class AuthorizePcInput
    {
        [Required]
        public string Token { get; set; }

        /// <summary>
        /// Should be set if you want to request tokens.
        /// </summary>
        public string AppId { get; set; }
    }
}