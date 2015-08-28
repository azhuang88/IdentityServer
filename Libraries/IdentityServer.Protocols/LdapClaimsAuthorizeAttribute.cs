using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization;

namespace IdentityServer.Protocols
{
    public class LdapClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private const string _label = "Thinktecture.IdentityModel.Authorization.Mvc.ClaimsAuthorizeAttribute";
        private string _action;
        private string[] _resources;

        public LdapClaimsAuthorizeAttribute()
        {
        }

        public LdapClaimsAuthorizeAttribute(string action, params string[] resources)
        {
            this._action = action;
            this._resources = resources;
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Items[(object)"Thinktecture.IdentityModel.Authorization.Mvc.ClaimsAuthorizeAttribute"] = (object)filterContext;
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!string.IsNullOrWhiteSpace(this._action))
                return ClaimsAuthorization.CheckAccess(this._action, this._resources);
            return this.CheckAccess(httpContext.Items[(object)"Thinktecture.IdentityModel.Authorization.Mvc.ClaimsAuthorizeAttribute"] as System.Web.Mvc.AuthorizationContext);
        }

        protected virtual bool CheckAccess(System.Web.Mvc.AuthorizationContext filterContext)
        {
            return ClaimsAuthorization.CheckAccess(filterContext.RouteData.Values["action"] as string, filterContext.RouteData.Values["controller"] as string, new Claim[0]);
        }
    }
}
