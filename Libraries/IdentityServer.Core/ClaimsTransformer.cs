/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Claims;
using IdentityServer.Repositories;

namespace IdentityServer
{
    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        public ClaimsTransformer()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        [Import]
        public IUserRepository UserRepository { get; set; }

        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
            {
                return base.Authenticate(resourceName, incomingPrincipal);
            }

            UserRepository.GetRoles(incomingPrincipal.Identity.Name).ToList().ForEach(role =>
                incomingPrincipal.Identities.First()
                    .AddClaim(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, Constants.InternalIssuer)));

            return incomingPrincipal;
        }
    }
}