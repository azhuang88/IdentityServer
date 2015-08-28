using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlobalConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    SiteName = c.String(false),
                    IssuerUri = c.String(false),
                    IssuerContactEmail = c.String(false),
                    DefaultWSTokenType = c.String(false),
                    DefaultHttpTokenType = c.String(false),
                    DefaultTokenLifetime = c.Int(false),
                    MaximumTokenLifetime = c.Int(false),
                    SsoCookieLifetime = c.Int(false),
                    RequireEncryption = c.Boolean(false),
                    RequireRelyingPartyRegistration = c.Boolean(false),
                    EnableClientCertificateAuthentication = c.Boolean(false),
                    EnforceUsersGroupMembership = c.Boolean(false),
                    HttpPort = c.Int(false),
                    HttpsPort = c.Int(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.WSFederationConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    Enabled = c.Boolean(false),
                    EnableAuthentication = c.Boolean(false),
                    EnableFederation = c.Boolean(false),
                    EnableHrd = c.Boolean(false),
                    AllowReplyTo = c.Boolean(false),
                    RequireReplyToWithinRealm = c.Boolean(false),
                    RequireSslForReplyTo = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.KeyMaterialConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    SigningCertificateName = c.String(),
                    DecryptionCertificateName = c.String(),
                    RSASigningKey = c.String(),
                    SymmetricSigningKey = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.WSTrustConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    Enabled = c.Boolean(false),
                    EnableMessageSecurity = c.Boolean(false),
                    EnableMixedModeSecurity = c.Boolean(false),
                    EnableClientCertificateAuthentication = c.Boolean(false),
                    EnableFederatedAuthentication = c.Boolean(false),
                    EnableDelegation = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.FederationMetadataConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    Enabled = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OAuth2Configuration",
                c => new
                {
                    Id = c.Int(false, true),
                    Enabled = c.Boolean(false),
                    EnableConsent = c.Boolean(false),
                    EnableResourceOwnerFlow = c.Boolean(false),
                    EnableImplicitFlow = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SimpleHttpConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    Enabled = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.DiagnosticsConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    EnableFederationMessageTracing = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ClientCertificates",
                c => new
                {
                    Id = c.Int(false, true),
                    UserName = c.String(false),
                    Thumbprint = c.String(false),
                    Description = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Delegation",
                c => new
                {
                    Id = c.Int(false, true),
                    UserName = c.String(false),
                    Realm = c.String(false),
                    Description = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.RelyingParties",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false),
                    Enabled = c.Boolean(false),
                    Realm = c.String(false),
                    TokenLifeTime = c.Int(false),
                    ReplyTo = c.String(),
                    EncryptingCertificate = c.String(),
                    SymmetricSigningKey = c.String(),
                    ExtraData1 = c.String(),
                    ExtraData2 = c.String(),
                    ExtraData3 = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.IdentityProvider",
                c => new
                {
                    ID = c.Int(false, true),
                    Name = c.String(false),
                    DisplayName = c.String(false),
                    Type = c.Int(false),
                    ShowInHrdSelection = c.Boolean(false),
                    WSFederationEndpoint = c.String(),
                    IssuerThumbprint = c.String(),
                    ClientID = c.String(),
                    ClientSecret = c.String(),
                    OAuth2ProviderType = c.Int(),
                    Enabled = c.Boolean(false)
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Client",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false),
                    Description = c.String(false),
                    ClientId = c.String(false),
                    ClientSecret = c.String(false),
                    RedirectUri = c.String(),
                    NativeClient = c.Boolean(false),
                    AllowImplicitFlow = c.Boolean(false),
                    AllowResourceOwnerFlow = c.Boolean(false),
                    AllowCodeFlow = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Client");
            DropTable("dbo.IdentityProvider");
            DropTable("dbo.RelyingParties");
            DropTable("dbo.Delegation");
            DropTable("dbo.ClientCertificates");
            DropTable("dbo.DiagnosticsConfiguration");
            DropTable("dbo.SimpleHttpConfiguration");
            DropTable("dbo.OAuth2Configuration");
            DropTable("dbo.FederationMetadataConfiguration");
            DropTable("dbo.WSTrustConfiguration");
            DropTable("dbo.KeyMaterialConfiguration");
            DropTable("dbo.WSFederationConfiguration");
            DropTable("dbo.GlobalConfiguration");
        }
    }
}