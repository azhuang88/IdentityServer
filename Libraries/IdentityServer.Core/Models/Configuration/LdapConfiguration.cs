using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Models.Configuration
{
    public class LdapConfiguration
    {
        public bool Enabled { get; set; }
        public string SiteTitle { get; set; }
        public string LdapConnectionString { get; set; }
        public string Domain { get; set; }
    }
}
