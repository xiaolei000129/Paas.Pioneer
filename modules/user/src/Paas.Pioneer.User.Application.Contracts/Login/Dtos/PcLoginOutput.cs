using System;

namespace Paas.Pioneer.User.Application.Contracts.Login.Dtos;

[Serializable]
public class PcLoginOutput
{
    public bool IsSuccess { get; set; }
}