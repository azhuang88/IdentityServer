using System.ComponentModel.DataAnnotations;
using IdentityServer;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class RoleInputModel
    {
        [Required]
        public string Name { get; set; }
        
        [System.Web.Mvc.HiddenInput(DisplayValue=false)]
        public bool Delete { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public bool CanDelete
        {
            get
            {
                if (Name == null) return false;
                return !Name.StartsWith(Constants.Roles.InternalRolesPrefix);
            }
        }
    }
}