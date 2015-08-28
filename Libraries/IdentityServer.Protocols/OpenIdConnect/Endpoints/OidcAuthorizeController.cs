/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Web.Mvc;
using IdentityServer.Protocols.OAuth2;
using IdentityServer.Repositories;

namespace IdentityServer.Protocols.OpenIdConnect.Endpoints
{
    public class OidcAuthorizeController : OidcAuthorizeControllerBase
    {
        public OidcAuthorizeController()
        {
        }

        public OidcAuthorizeController(IOpenIdConnectClientsRepository clients, IStoredGrantRepository grants)
            : base(clients, grants)
        {
        }

        protected override ActionResult ShowConsent(ValidatedRequest validatedRequest)
        {
            Tracing.Information("OIDC Consent screen");

            return View("Consent", new OidcViewModel(validatedRequest));
        }

        [ActionName("Index")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleConsent(AuthorizeRequest request, string button, string[] selectedScopes)
        {
            Tracing.Start("OIDC consent response");

            ValidatedRequest validatedRequest;
            ActionResult failedResult;
            if (!TryValidateRequest(request, out validatedRequest, out failedResult))
            {
                Tracing.Error("Aborting OIDC consent response");
                return failedResult;
            }

            if (button == "allow")
            {
                var vm = new OidcViewModel(validatedRequest);
                vm.SetScopes(selectedScopes);
                return PerformGrant(vm.ValidatedRequest);
            }
            return DenyGrant(validatedRequest);
        }
    }
}