using System.ComponentModel.Composition;
using System.Web.Mvc;
using IdentityServer;
using Thinktecture.IdentityModel.Authorization.WebApi;
using IdentityServer.Repositories;
using ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.Controllers
{
    [ClaimsAuthorize(Constants.Actions.Administration, Constants.Resources.Configuration)]
    public class OAuthRefreshTokenController : Controller
    {
        [Import]
        public IClientsRepository clientRepository { get; set; }
        [Import]
        ICodeTokenRepository codeTokenRepository { get; set; }

        public OAuthRefreshTokenController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public OAuthRefreshTokenController(
            IClientsRepository clientRepository, ICodeTokenRepository codeTokenRepository)
        {
            this.clientRepository = clientRepository;
            this.codeTokenRepository = codeTokenRepository;
        }

        public ActionResult Index(TokenSearchCriteria searchCriteria)
        {
            var vm = new OAuthRefreshTokenIndexViewModel(searchCriteria, clientRepository, codeTokenRepository);
            return View("Index", vm);
        }
        
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(TokenSearchCriteria searchCriteria)
        {
            var vm = new OAuthRefreshTokenIndexViewModel(searchCriteria, clientRepository, codeTokenRepository, true);
            return View("Index", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteToken(string token, TokenSearchCriteria searchCriteria)
        {
            codeTokenRepository.DeleteCode(token);
            return RedirectToAction("Index", new { searchCriteria.Username, searchCriteria.Scope, searchCriteria.ClientID });
        }
    }
}
