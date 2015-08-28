using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
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
                    UserNameAuthenticationEndpoint = c.String(),
                    FederationEndpoint = c.String(),
                    IssuerUri = c.String(),
                    IssuerThumbprint = c.String(),
                    EncryptionCertificate = c.String()
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.AdfsIntegrationConfiguration");
        }
    }
}