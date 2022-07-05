using System.ComponentModel.DataAnnotations;

namespace Paas.Pioneer.User.Application.Contracts.Login.Dtos;

public class RefreshInput
{
    [Required]
    public string RefreshToken { get; set; }
}