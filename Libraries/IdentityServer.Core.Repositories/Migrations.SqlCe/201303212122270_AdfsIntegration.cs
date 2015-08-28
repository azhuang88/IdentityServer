using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlCe
{
    public partial class AdfsIntegration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdfsIntegrationConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    Enabled = c.Boolean(false),
                    UsernameAuthenticationEnabled = c.Boolean(false),
                    SamlAuthenticationEnabled = c.Boolean(false),
                    JwtAuthenticationEnabled = c.Boolean(false),
                    PassThruAuthenticationToken = c.Boolean(false),
                    AuthenticationTokenLifetime = c.Int(false),
                    UserNameAuthenticationEndpoint = c.String(maxLength: 4000),
                    FederationEndpoint = c.String(maxLength: 4000),
                    IssuerUri = c.String(maxLength: 4000),
                    IssuerThumbprint = c.String(maxLength: 4000),
                    EncryptionCertificate = c.String(maxLength: 4000)
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.AdfsIntegrationConfiguration");
        }
    }
}