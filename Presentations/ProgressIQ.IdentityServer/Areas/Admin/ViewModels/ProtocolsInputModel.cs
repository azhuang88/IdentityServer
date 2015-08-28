using System.ComponentModel.DataAnnotations;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class ProtocolsInputModel
    {
        [Required]
        public bool[] Protocols { get; set; }

        public void Update(IConfigurationRepository configurationRepository)
        {
            new ProtocolsViewModel(configurationRepository).Update(this.Protocols);
        }
    }
}