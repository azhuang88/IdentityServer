using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityServer;
using IdentityServer.Models.Configuration;
using IdentityServer.Protocols.LdapIntegration;
using IdentityServer.Repositories;
using ProgressIQ.IdentityServer.Web.Utility;
using Thinktecture.IdentityModel.Authorization.Mvc;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.Controllers
{
    [ClaimsAuthorize(Constants.Actions.Administration, Constants.Resources.Configuration)]

    public class LdapConfigurationController : Controller
    {
        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }
        // GET: Admin/Ldap

        public LdapConfigurationController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public LdapConfigurationController(IConfigurationRepository configuration)
        {
            ConfigurationRepository = configuration;
        }

        public ActionResult Index()
        {
            var model = ConfigurationRepository.LdapConfiguration;
            return View("Index",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action",Argument = "Save")]
        public ActionResult Index(LdapConfiguration model)
        {
                if (ModelState.IsValid)
            {
                try
                {
                    ConfigurationRepository.LdapConfiguration = model;
                    TempData["Message"] = Resources.LdapConfigurationController.UpdateSuccessful;
                    return RedirectToAction("Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch
                {
                    ModelState.AddModelError("",Resources.LdapConfigurationController.ErrorUpdatingConfiguration);
                }
            }
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "Test")]
        public ActionResult Index(FormCollection form, LdapConfiguration model)
        {
            var email = form["email"];
            var password = form["password"];

            if (ModelState.IsValid && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var objLdap = new LdapManager(model);
                
                if (objLdap.Authenticate(email, password))
                {
                    TempData["Message"] = "Connection sucessful establish.";
                }
                else
                {
                    ModelState.AddModelError("",@"Test failed");
                }
            }
            else
            {
                ModelState.AddModelError("",@"Please input username password");
            }

            return View("Index");
        }
    }

}