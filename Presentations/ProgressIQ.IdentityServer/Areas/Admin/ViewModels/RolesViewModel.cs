using System.Collections.Generic;
using System.Linq;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class RolesViewModel
    {
        private IUserManagementRepository UserManagementRepository;
        public IEnumerable<RoleInputModel> Roles { get; set; }

        public RolesViewModel(IUserManagementRepository UserManagementRepository)
        {
            this.UserManagementRepository = UserManagementRepository;
            this.Roles =
                UserManagementRepository
                    .GetRoles()
                    .Select(x => new RoleInputModel { Name = x })
                    .OrderBy(x=>x.CanDelete)
                    .ToArray();
        }
    }
}