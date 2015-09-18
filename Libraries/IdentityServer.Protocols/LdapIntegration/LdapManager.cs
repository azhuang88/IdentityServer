using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Threading.Tasks;
using IdentityServer.Core.Helper;
using IdentityServer.Models.Configuration;
using IdentityServer.Repositories;


namespace IdentityServer.Protocols.LdapIntegration
{
    public class LdapManager
    {
        private readonly LdapConfiguration _ldap;
        public LdapManager()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public LdapManager(LdapConfiguration ldap)
        {
            _ldap = ldap;
        }

        #region "Methods"

        public bool Authenticate(string email, string password)
        {
            var domain = _ldap.Domain;
            var arUser = email.Split('@');
            if (EmailHelper.IsValidEmail(email) && arUser[1].ToLower() == domain)
            {
                var de = new DirectoryEntry("GC://" + LdapDomain(), arUser[0], password, AuthenticationTypes.Secure);

                try
                {
                    var test = de.Name;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public string SearchBy(string username,string searchType)
        {
            var entry = new DirectoryEntry(_ldap.LdapConnectionString);

            var search = new DirectorySearcher
            {
                SearchRoot = entry,
                Filter = "(sAMAccountName=" + username + ")",
                SearchScope = SearchScope.Subtree
            };

            return search.FindAll().Cast<SearchResult>().Where(result => result.Properties[searchType].Count > 0).Aggregate("", (current, result) => current + result.Properties[searchType][0]);
        }

        private string LdapDomain()
        {
            return _ldap.LdapConnectionString.ToLower().Replace("ldap://", "").Split('/')[0];
        }
        #endregion

        #region "Properties"
        
        #endregion
    }
}
