/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using IdentityServer.Repositories;
using IdentityServer.TokenService;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.Constants;

namespace IdentityServer.Protocols.OpenIdConnect
{
    [Authorize]
    public class OidcUserInfoController : ApiController
    {
        public OidcUserInfoController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public OidcUserInfoController(IClaimsRepository claimsRepository)
        {
            ClaimsRepository = claimsRepository;
        }

        [Import]
        public IClaimsRepository ClaimsRepository { get; set; }

        public HttpResponseMessage Get()
        {
            Tracing.Start("OIDC UserInfo endpoint");

            var details = new RequestDetails {IsOpenIdRequest = true};
            var scopeClaims = ClaimsPrincipal.Current.FindAll(OAuth2Constants.Scope).ToList();
            var requestedClaims = ClaimsPrincipal.Current.FindAll("requestclaim").ToList();

            if (scopeClaims.Count > 0)
            {
                var scopes = new List<string>(scopeClaims.Select(sc => sc.Value));
                details.OpenIdScopes = scopes;
            }

            if (requestedClaims.Count > 0)
            {
                var requestClaims = new RequestClaimCollection();
                requestedClaims.ForEach(rc => requestClaims.Add(new RequestClaim(rc.Value)));

                details.ClaimsRequested = true;
                details.RequestClaims = requestClaims;
            }

            var principal = Principal.Create("OpenIdConnect",
                new Claim(ClaimTypes.Name, ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value));

            var claims = ClaimsRepository.GetClaims(principal, details);

            var dictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                if (!dictionary.ContainsKey(claim.Type))
                {
                    dictionary.Add(claim.Type, claim.Value);
                }
                else
                {
                    var currentValue = dictionary[claim.Type];
                    dictionary[claim.Type] = currentValue += ("," + claim.Value);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, dictionary, "application/json");
        }
    }
}