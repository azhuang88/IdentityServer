using System.Linq;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class OAuthClientIndexViewModel
    {
        private IClientsRepository clientsRepository;
        public OAuthClientIndexInputModel[] Clients
        {
            get;
            private set;
        }

        public OAuthClientIndexViewModel(IClientsRepository clientsRepository)
        {
            // TODO: Complete member initialization
            this.clientsRepository = clientsRepository;
            this.Clients = this.clientsRepository.GetAll().Select(x=>new OAuthClientIndexInputModel{Name=x.Name, ID=x.ID}).ToArray();
        }
    }

    public class OAuthClientIndexInputModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool Delete { get; set; }
    }

}