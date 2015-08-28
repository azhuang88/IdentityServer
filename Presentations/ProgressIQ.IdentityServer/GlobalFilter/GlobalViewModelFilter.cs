using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdentityServer;
using IdentityServer.Repositories;
using Thinktecture.IdentityModel.Authorization;
using System.ComponentModel.Composition;

namespace ProgressIQ.IdentityServer.Web.GlobalFilter
{
    public class GlobalViewModelFilter : ActionFilterAttribute
    {
        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Container.Current.SatisfyImportsOnce(this);

            filterContext.Controller.ViewBag.SiteName = ConfigurationRepository.Global.SiteName;
            filterContext.Controller.ViewBag.IsAdministrator = ClaimsAuthorization.CheckAccess(Constants.Actions.Administration, Constants.Resources.UI);
            filterContext.Controller.ViewBag.IsSignedIn = filterContext.HttpContext.User.Identity.IsAuthenticated;

            base.OnActionExecuting(filterContext);
        }
    }
}
