using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IdentityModel.Selectors;
using System.IdentityModel.Services;
using System.IdentityModel.Services.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using IdentityServer.Protocols.LdapIntegration;
using IdentityServer.Repositories;
using IdentityServer.TokenService;
using Newtonsoft.Json.Linq;
using Thinktecture.IdentityModel.Authorization;
using Thinktecture.IdentityModel.Authorization.Mvc;

namespace IdentityServer.Protocols.WSFederation
{
    public class AtozController : Controller
    {
        private const string _cookieName = "atozsignout";

        #region "WS Federation"
        public AtozController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public AtozController(IConfigurationRepository configurationRepository,
            IIdentityProviderRepository identityProviderRepository)
        {
            IdentityProviderRepository = identityProviderRepository;
            ConfigurationRepository = configurationRepository;
        }

        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        [Import]
        public IIdentityProviderRepository IdentityProviderRepository { get; set; }

        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Issue()
        {
            Tracing.Start("AZ-Federation endpoint.");

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
                return ProcessWSFederationSignIn(signinMessage);
            }

            // sign out
            var signoutMessage = message as SignOutRequestMessage;
            if (signoutMessage != null)
            {
                return ProcessWSFederationSignOut(signoutMessage);
            }

            return View("Error");
        }

        private ActionResult ProcessWSFederationSignIn(SignInRequestMessage message)
        {
            Tracing.Start("WS-Federation endpoint.");

            if (!ConfigurationRepository.WSFederation.Enabled &&
                ConfigurationRepository.WSFederation.EnableAuthentication)
            {
                return new HttpNotFoundResult();
            }

            if (User.Identity.IsAuthenticated)
            {
                return ProcessWSFederationSignIn(message, ClaimsPrincipal.Current);

            }
            return RedirectToAction("SignIn", new { ReturnUrl = HttpContext.Request.Url });
        }
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

        #region "Page SignIn"
        public ActionResult SignIn(string returnUrl, bool mobile = false)
        {
            // you can call AuthenticationHelper.GetRelyingPartyDetailsFromReturnUrl to get more information about the requested relying party
            var vm = new AtozViewModel
            {
                ReturnUrl = returnUrl,
                ShowClientCertificateLink = ConfigurationRepository.Global.EnableClientCertificateAuthentication
            };

            if (mobile) vm.IsSigninRequest = true;
            return View("AZ");
        }

        // handles the signin
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult SignIn(AtozViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (new LdapManager(ConfigurationRepository.LdapConfiguration.LdapConnectionString).Authenticate(GetUsername(model.Email), model.Password))
                {
                    // establishes a principal, set the session cookie and redirects
                    // you can also pass additional claims to signin, which will be embedded in the session token

                    return ProcessSignIn(
                        model.Email,
                        AuthenticationMethods.Password,
                        model.ReturnUrl,
                        false,
                        ConfigurationRepository.Global.SsoCookieLifetime);
                }
            }

            ModelState.AddModelError("", @"Incorrect credential or not authorize");

            model.ShowClientCertificateLink = ConfigurationRepository.Global.EnableClientCertificateAuthentication;
            return View("AZ",model);
        }

        protected virtual ActionResult ProcessSignIn(string userName, string authenticationMethod, string returnUrl,
            bool isPersistent, int ttl, IEnumerable<Claim> additionalClaims = null)
        {
            new AuthenticationHelper().SetSessionToken(
                userName,
                authenticationMethod,
                isPersistent,
                ttl,
                additionalClaims);

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region "Methods"
        private string GetUsername(string email)
        {
            return email.Split('@')[0];
        }
        #endregion

    }
}
