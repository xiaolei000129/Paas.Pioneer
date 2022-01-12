using System.Collections.Generic;
using System.Security.Claims;

namespace Paas.Pioneer.Domain.Shared.Auth
{
    public interface IUserToken
    {
        string Create(IEnumerable<Claim> claims);

        IEnumerable<Claim> Decode(string jwtToken);
    }
}