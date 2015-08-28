using System.Linq;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class IdentityProvidersViewModel
    {
        private IIdentityProviderRepository identityProviderRepository;

        public IdentityProvidersViewModel(IIdentityProviderRepository identityProviderRepository)
        {
            // TODO: Complete member initialization
            this.identityProviderRepository = identityProviderRepository;
            this.IdentityProviders =
                identityProviderRepository.GetAll()
                .Select(x => new IPModel { ID = x.ID, Name = x.DisplayName })
                .ToArray();
        }

        public IPModel[] IdentityProviders { get; set; }
    }

    public class IPModel 
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool Delete { get; set; }
    }
}