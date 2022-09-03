using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Utilities
{
    public class AddMyClaims: UserClaimsPrincipalFactory<User>
    {
        public AddMyClaims(UserManager<User> userManager, IOptions<IdentityOptions> option) : base(userManager, option)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier ,user.Id));
            var principal = new ClaimsPrincipal(identity);
            var token = new SessionSecurityToken((Microsoft.IdentityModel.Claims.IClaimsPrincipal)principal);
            FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(token);
            return identity;

        }
    }
}
