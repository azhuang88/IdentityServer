﻿using System.Linq;
using IdentityServer.Repositories;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class ClientCertificatesViewModel
    {
        private IClientCertificatesRepository clientCertificatesRepository;

        public ClientCertificateUserInputModel[] Users { get; set; }

        public ClientCertificatesViewModel()
        {

        }

        public ClientCertificatesViewModel(IClientCertificatesRepository clientCertificatesRepository)
        {
            this.clientCertificatesRepository = clientCertificatesRepository;
            this.Users =
                clientCertificatesRepository.List(-1, -1)
                .Select(x => new ClientCertificateUserInputModel
                {
                    Username = x
                }).ToArray();
        }
    }

    public class ClientCertificateUserInputModel
    {
        public string Username { get; set; }
        public bool Delete { get; set; }
    }
}