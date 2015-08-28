using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using IdentityServer.Models;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class ClientCertificatesForUserViewModel
    {
        private IClientCertificatesRepository clientCertificatesRepository;
        private IUserManagementRepository userManagementRepository;
        
        [Required]
        public string UserName { get; set; }
        public IEnumerable<ClientCertificate> Certificates { get; set; }

        public ClientCertificate NewCertificate { get; set; }

        public bool IsNew
        {
            get
            {
                return this.UserName == null;
            }
        }

        public IEnumerable<SelectListItem> AllUserNames { get; set; }

        public ClientCertificatesForUserViewModel(IClientCertificatesRepository clientCertificatesRepository, IUserManagementRepository userManagementRepository, string username)
        {
            this.clientCertificatesRepository = clientCertificatesRepository;
            this.userManagementRepository = userManagementRepository;
            int totalCount;
            var allnames =
                userManagementRepository.GetUsers(0, 100, out totalCount)
                .Select(x => new SelectListItem
                {
                    Text = x
                }).ToList();
            allnames.Insert(0, new SelectListItem { Text = Resources.ClientCertificatesForUserViewModel.ChooseItem, Value = "" });
            this.AllUserNames = allnames;
            
            this.UserName = username;
            NewCertificate = new ClientCertificate { UserName = username };
            if (!IsNew)
            {
                var certs =
                        this.clientCertificatesRepository
                        .GetClientCertificatesForUser(this.UserName)
                            .ToArray();
                this.Certificates = certs;
            }
            else
            {
                this.Certificates = new ClientCertificate[0];
            }
        }
    }
}