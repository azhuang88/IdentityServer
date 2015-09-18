using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Repositories.Sql.Configuration
{
    public class LdapConfiguration
    {
        [Key]
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string LdapConnectionString { get; set; }
        public string Domain { get; set; }
        public string SiteTitle { get; set; }
    }
}
