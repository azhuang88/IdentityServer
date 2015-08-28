using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Threading.Tasks;


namespace IdentityServer.Protocols.LdapIntegration
{
    public class LdapManager
    {
        private readonly string _ldapConnection;
        public LdapManager(string ldapConnection)
        {
            _ldapConnection = ldapConnection;
        }

        #region "Methods"

        public bool Authenticate(string username, string password)
        {
            var de = new DirectoryEntry("GC://" + LdapDomain(), username, password, AuthenticationTypes.Secure);

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

        public string SearchBy(string username,string searchType)
        {
            var entry = new DirectoryEntry(_ldapConnection);

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
            return _ldapConnection.ToLower().Replace("ldap://", "").Split('/')[0];
        }
        #endregion

        #region "Properties"
        
        #endregion
    }
}
