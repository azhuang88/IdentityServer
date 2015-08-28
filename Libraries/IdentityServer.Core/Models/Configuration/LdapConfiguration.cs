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
        public string LdapConnectionString { get; set; }
    }
}
