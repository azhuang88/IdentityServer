/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.Composition;
using System.IdentityModel.Services;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.UI;
using IdentityServer.Repositories;
using IdentityServer.TokenService;
using Thinktecture.IdentityModel.Authorization.Mvc;

namespace IdentityServer.Protocols.WSFederation
{
    [ClaimsAuthorize(Constants.Actions.Issue, Constants.Resources.WSFederation)]
    public class WSFederationController : Controller
    {
        private const string _cookieName = "wsfedsignout";

        public WSFederationController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public WSFederationController(IConfigurationRepository configurationRepository)
        {
            ConfigurationRepository = configurationRepository;
        }

        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Issue()
        {
            Tracing.Start("WS-Federation endpoint.");

            if (!ConfigurationRepository.WSFederation.Enabled &&
                ConfigurationRepository.WSFederation.EnableAuthentication)
            {
                return new HttpNotFoundResult();
            }

            var message = WSFederationMessage.CreateFromUri(HttpContext.Request.Url);

            // sign in 
            var signinMessage = message as SignInRequestMessage;
            if (signinMessage != null)
            {
                return ProcessWSFederationSignIn(signinMessage, ClaimsPrincipal.Current);
            }

            // sign out
            var signoutMessage = message as SignOutRequestMessage;
            if (signoutMessage != null)
            {
                return ProcessWSFederationSignOut(signoutMessage);
            }

            return View("Error");
        }

        #region Helper

        private ActionResult ProcessWSFederationSignIn(SignInRequestMessage message, ClaimsPrincipal principal)
        {
            // issue token and create ws-fed response
            var response = FederatedPassiveSecurityTokenServiceOperations.ProcessSignInRequest(
                message,
                principal,
                TokenServiceConfiguration.Current.CreateSecurityTokenService());

            // set cookie for single-sign-out
            new SignInSessionsManager(HttpContext, _cookieName, ConfigurationRepository.Global.MaximumTokenLifetime)
                .AddEndpoint(response.BaseUri.AbsoluteUri);

            return new WSFederationResult(response, ConfigurationRepository.WSFederation.RequireSslForReplyTo);
        }

        private ActionResult ProcessWSFederationSignOut(SignOutRequestMessage message)
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            var mgr = new SignInSessionsManager(HttpContext, _cookieName);

            // check for return url
            if (!string.IsNullOrWhiteSpace(message.Reply) && mgr.ContainsUrl(message.Reply))
            {
                ViewBag.ReturnUrl = message.Reply;
            }

            // check for existing sign in sessions
            var realms = mgr.GetEndpoints();
            mgr.ClearEndpoints();

            return View("Signout", realms);
        }

        #endregion
    }
}