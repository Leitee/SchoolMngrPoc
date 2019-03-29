using Pandora.NetStandard.Core.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Pandora.NetStandard.Core.Security
{
    public class ClaimsExtension
    {
        protected virtual IEnumerable<Claim> CreateClaimsByConditions(ApplicationUser user)
        {

            List<Claim> claims = new List<Claim>();

            var daysInWork = (DateTime.UtcNow.Date - user.JoinDate).TotalDays;

            if (daysInWork > 90)
            {
                claims.Add(CreateClaim("FTE", "1"));

            }
            else
            {
                claims.Add(CreateClaim("FTE", "0"));
            }

            return claims;
        }

        protected virtual IEnumerable<Claim> CreateRolesBasedOnClaims(ClaimsIdentity identity)
        {
            List<Claim> claims = new List<Claim>();

            if (identity.HasClaim(c => c.Type == "FTE" && c.Value == "1") &&
                identity.HasClaim(ClaimTypes.Role, "Admin"))
            {
                claims.Add(new Claim(ClaimTypes.Role, "IncidentResolvers"));
            }

            return claims;
        }

        public static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, ClaimValueTypes.String);
        }
    }
}
