using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlCe
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
                    SiteName = c.String(false, 4000),
                    IssuerUri = c.String(false, 4000),
                    IssuerContactEmail = c.String(false, 4000),
                    DefaultWSTokenType = c.String(false, 4000),
                    DefaultHttpTokenType = c.String(false, 4000),
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
                    SigningCertificateName = c.String(maxLength: 4000),
                    DecryptionCertificateName = c.String(maxLength: 4000),
                    RSASigningKey = c.String(maxLength: 4000),
                    SymmetricSigningKey = c.String(maxLength: 4000)
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
                    UserName = c.String(false, 4000),
                    Thumbprint = c.String(false, 4000),
                    Description = c.String(false, 4000)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Delegation",
                c => new
                {
                    Id = c.Int(false, true),
                    UserName = c.String(false, 4000),
                    Realm = c.String(false, 4000),
                    Description = c.String(maxLength: 4000)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.RelyingParties",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 4000),
                    Enabled = c.Boolean(false),
                    Realm = c.String(false, 4000),
                    TokenLifeTime = c.Int(false),
                    ReplyTo = c.String(maxLength: 4000),
                    EncryptingCertificate = c.String(),
                    SymmetricSigningKey = c.String(maxLength: 4000),
                    ExtraData1 = c.String(maxLength: 4000),
                    ExtraData2 = c.String(maxLength: 4000),
                    ExtraData3 = c.String(maxLength: 4000)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.IdentityProvider",
                c => new
                {
                    ID = c.Int(false, true),
                    Name = c.String(false, 4000),
                    DisplayName = c.String(false, 4000),
                    Type = c.Int(false),
                    ShowInHrdSelection = c.Boolean(false),
                    WSFederationEndpoint = c.String(maxLength: 4000),
                    IssuerThumbprint = c.String(maxLength: 4000),
                    ClientID = c.String(maxLength: 4000),
                    ClientSecret = c.String(maxLength: 4000),
                    OAuth2ProviderType = c.Int(),
                    Enabled = c.Boolean(false)
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Client",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 4000),
                    Description = c.String(false, 4000),
                    ClientId = c.String(false, 4000),
                    ClientSecret = c.String(false, 4000),
                    RedirectUri = c.String(maxLength: 4000),
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