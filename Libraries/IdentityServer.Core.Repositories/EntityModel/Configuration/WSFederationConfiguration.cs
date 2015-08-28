using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql.Configuration
{
    public class WSFederationConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public bool EnableAuthentication { get; set; }

        [Required]
        public bool EnableFederation { get; set; }

        [Required]
        public bool EnableHrd { get; set; }

        [Required]
        public bool EnableAz { get; set; }

        [Required]
        public bool AllowReplyTo { get; set; }

        [Required]
        public bool RequireReplyToWithinRealm { get; set; }

        [Required]
        public bool RequireSslForReplyTo { get; set; }
    }
}