using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Extensions
{
    public static class UserClaimPrincipalExtensions
    {
        public static List<string> GetClaim(this ClaimsPrincipal claims,string type)
        {
            return claims?.FindAll(type)?.Select(x => x.Value).ToList();
        }
        public static List<string> GetRoles(this ClaimsPrincipal claims)
        {
            return claims?.GetClaim(ClaimTypes.Role);
        }
        public static string GetEmail(this ClaimsPrincipal claims)
        {
            string email = claims?.GetClaim(ClaimTypes.Email)?.First();
            return email;
        }
    }
}
