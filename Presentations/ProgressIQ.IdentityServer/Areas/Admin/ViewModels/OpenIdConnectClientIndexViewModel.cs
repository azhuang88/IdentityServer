using System.Linq;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class OpenIdConnectClientIndexViewModel
    {
        private IOpenIdConnectClientsRepository clientsRepository;
        public OpenIdConnectClientIndexInputModel[] Clients
        {
            get;
            private set;
        }

        public OpenIdConnectClientIndexViewModel(IOpenIdConnectClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
            this.Clients = this.clientsRepository.GetAll().Select(x => new OpenIdConnectClientIndexInputModel { Name = x.Name, ClientId = x.ClientId }).ToArray();
        }
    }

    public class OpenIdConnectClientIndexInputModel
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public bool Delete { get; set; }
    }

}