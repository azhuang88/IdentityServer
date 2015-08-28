using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql.Configuration
{
    public class DiagnosticsConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool EnableFederationMessageTracing { get; set; }
    }
}