using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer.Models;
using IdentityServer.TokenService;

namespace IdentityServer.Repositories
{
    public interface IClaimsTransformationRulesRepository
    {
        IEnumerable<Claim> ProcessClaims(ClaimsPrincipal incomingPrincipal, IdentityProvider identityProvider,
            RequestDetails details);
    }
}