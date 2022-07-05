using System;

namespace Paas.Pioneer.User.Application.Contracts.Login.Dtos;

public class LoginOutput
{
    public Guid? TenantId { get; set; }

    public string RawData { get; set; }
}