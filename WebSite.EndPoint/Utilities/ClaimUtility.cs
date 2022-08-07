using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Utilities
{
    public class ClaimUtility
    {
        public static string basketCookieName = "BasketId";
        public static string GetUserId(ClaimsPrincipal claims)
        {
            var claimsIdentity = claims.Identity as ClaimsPrincipal;
            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;
        }
    }
}
