using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql.Configuration
{
    public class WSTrustConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public bool EnableMessageSecurity { get; set; }

        [Required]
        public bool EnableMixedModeSecurity { get; set; }

        [Required]
        public bool EnableClientCertificateAuthentication { get; set; }

        [Required]
        public bool EnableFederatedAuthentication { get; set; }

        [Required]
        public bool EnableDelegation { get; set; }
    }
}