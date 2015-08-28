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
    public class DiagnosticsController : Controller
    {
        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        public DiagnosticsController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public DiagnosticsController(IConfigurationRepository configuration)
        {
            ConfigurationRepository = configuration;
        }

        public ActionResult Index()
        {
            var vm = this.ConfigurationRepository.Diagnostics;
            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DiagnosticsConfiguration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ConfigurationRepository.Diagnostics = model;
                    TempData["Message"] = Resources.DiagnosticsController.UpdateSuccessful;
                    return RedirectToAction("Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch
                {
                    ModelState.AddModelError("", Resources.DiagnosticsController.ErrorUpdatingDiagnostics);
                }
            }

            return View("Index", model);
        }

    }
}
