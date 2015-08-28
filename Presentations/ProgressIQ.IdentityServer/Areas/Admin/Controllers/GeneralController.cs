using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using IdentityServer;
using Thinktecture.IdentityModel.Authorization.Mvc;
using IdentityServer.Models.Configuration;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.Controllers
{
    [ClaimsAuthorize(Constants.Actions.Administration, Constants.Resources.Configuration)]
    public class GeneralController : Controller
    {
        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        public GeneralController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public GeneralController(IConfigurationRepository configuration)
        {
            ConfigurationRepository = configuration;
        }

        public ActionResult Index()
        {
            var model = ConfigurationRepository.Global;
            return View("Index", model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GlobalConfiguration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ConfigurationRepository.Global = model;
                    TempData["Message"] = Resources.GeneralController.UpdateSuccessful;
                    return RedirectToAction("Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch
                {
                    ModelState.AddModelError("", Resources.GeneralController.ErrorUpdatingConfiguration);
                }
            }

            return View("Index", model);
        }

        public ActionResult Recycle()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Recycle")]
        public ActionResult RecyclePost()
        {
            System.Web.Hosting.HostingEnvironment.InitiateShutdown();
            return RedirectToAction("Recycle");
        }
    }
}
