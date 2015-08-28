/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Security;

namespace IdentityServer.Repositories
{
    public class ProviderUserRepository : IUserRepository
    {
        public ProviderUserRepository()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        [Import]
        public IClientCertificatesRepository Repository { get; set; }

        public virtual bool ValidateUser(string userName, string password)
        {
            return Membership.ValidateUser(userName, password);
        }

        public virtual bool ValidateUser(X509Certificate2 clientCertificate, out string userName)
        {
            return Repository.TryGetUserNameFromThumbprint(clientCertificate, out userName);
        }

        public virtual IEnumerable<string> GetRoles(string userName)
        {
            var returnedRoles = new List<string>();

            if (Roles.Enabled)
            {
                var roles = Roles.GetRolesForUser(userName);
                returnedRoles = roles.Where(role => role.StartsWith(Constants.Roles.InternalRolesPrefix)).ToList();
            }

            return returnedRoles;
        }
    }
}