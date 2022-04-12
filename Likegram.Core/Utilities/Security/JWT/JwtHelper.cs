using Likegram.Core.Entities.Concrete;
using Likegram.Core.Extensions;
using Likegram.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(User user, List<Role> roles)
        {
            _accessTokenExpiration = DateTime.Now.AddDays(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityToken(_tokenOptions.SecurityKey);
            var signinCredentials = SigninCredentialsHelper.CreateSigninCredentialsHelpers(securityKey);
            var jwt = CreateJwtSecurityToken(user, signinCredentials, roles, _accessTokenExpiration);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            string token = jwtTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(User user, SigningCredentials signinCredentials, List<Role> roles, DateTime accessTokenExpiration)
        {
            return new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                notBefore: DateTime.Now,
                expires: accessTokenExpiration,
                signingCredentials: signinCredentials,
                claims: SetClaims(user, roles));
        }

        private IEnumerable<Claim> SetClaims(User user, List<Role> roles)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRole(roles.Select(x=>x.Name).ToArray());
            return claims;
        }
    }
}
