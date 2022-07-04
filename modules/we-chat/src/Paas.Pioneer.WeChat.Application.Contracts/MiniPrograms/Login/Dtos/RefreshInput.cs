using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.WeChat.Application.Contracts.MiniPrograms.Login.Dtos
{
    public class RefreshInput
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}