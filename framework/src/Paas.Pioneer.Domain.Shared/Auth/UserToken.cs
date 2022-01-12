using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Paas.Pioneer.Domain.Shared.Configs;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Paas.Pioneer.Domain.Shared.Auth
{
    public class UserToken : IUserToken, ITransientDependency
    {
        private readonly IOptions<JwtConfig> _jwtConfig;

        public UserToken(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public string Create(IEnumerable<Claim> claims)
        {
            int expires = _jwtConfig.Value.Expires;
            int refreshexpires = _jwtConfig.Value.RefreshExpires;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Value.SecurityKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var timestamp = DateTime.Now.AddMinutes(expires + refreshexpires).ToTimestamp().ToString();
            claims = claims.Append(new Claim(ClaimAttributes.RefreshExpires, timestamp));

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Value.Issuer,
                audience: _jwtConfig.Value.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(expires),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> Decode(string jwtToken)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(jwtToken);
            return jwtSecurityToken?.Claims;
        }
    }
}