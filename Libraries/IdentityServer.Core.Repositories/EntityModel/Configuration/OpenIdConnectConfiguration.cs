using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql.Configuration
{
    public class OpenIdConnectConfiguration
    {
        [Key]
        public int Id { get; set; }

        public bool Enabled { get; set; }
    }
}