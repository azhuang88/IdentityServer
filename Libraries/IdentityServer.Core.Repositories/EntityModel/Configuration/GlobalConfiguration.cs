using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql.Configuration
{
    public class GlobalConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SiteName { get; set; }

        [Required]
        public string IssuerUri { get; set; }

        [Required]
        public string IssuerContactEmail { get; set; }

        [Required]
        public string DefaultWSTokenType { get; set; }

        [Required]
        public string DefaultHttpTokenType { get; set; }

        [Required]
        public int DefaultTokenLifetime { get; set; }

        [Required]
        public int MaximumTokenLifetime { get; set; }

        [Required]
        public int SsoCookieLifetime { get; set; }

        [Required]
        public bool RequireEncryption { get; set; }

        [Required]
        public bool RequireRelyingPartyRegistration { get; set; }

        [Required]
        public bool EnableClientCertificateAuthentication { get; set; }

        [Required]
        public bool EnforceUsersGroupMembership { get; set; }

        [Required]
        public int HttpPort { get; set; }

        [Required]
        public int HttpsPort { get; set; }

        [Required]
        public bool DisableSSL { get; set; }

        public string PublicHostName { get; set; }
    }
}