/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IdentityModel.Services;
using System.Security.Claims;
using System.Web.Mvc;
using IdentityServer.Repositories;

namespace IdentityServer.Protocols
{
    public class AccountControllerBase : Controller
    {
        public AccountControllerBase()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public AccountControllerBase(IUserRepository userRepository, IConfigurationRepository configurationRepository)
        {
            UserRepository = userRepository;
            ConfigurationRepository = configurationRepository;
        }

        [Import]
        public IUserRepository UserRepository { get; set; }

        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        public ActionResult SignOut()
        {
            if (Request.IsAuthenticated)
            {
                FederatedAuthentication.SessionAuthenticationModule.DeleteSessionTokenCookie();
            }

            return RedirectToAction("Index", "Home");
        }

        #region Private

        protected virtual ActionResult SignIn(string userName, string authenticationMethod, string returnUrl,
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
                return RedirectToLocal(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}