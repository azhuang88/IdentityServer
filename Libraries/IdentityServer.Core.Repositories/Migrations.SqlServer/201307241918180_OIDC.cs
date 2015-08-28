using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
{
    public partial class OIDC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpenIdConnectConfiguration",
                c => new
                {
                    Id = c.Int(false, true),
                    Enabled = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OpenIdConnectClients",
                c => new
                {
                    ClientId = c.String(false, 128),
                    ClientSecret = c.String(false),
                    ClientSecretType = c.Int(false),
                    Name = c.String(false),
                    Flow = c.Int(false),
                    AllowRefreshToken = c.Boolean(false),
                    AccessTokenLifetime = c.Int(false),
                    RefreshTokenLifetime = c.Int(false),
                    RequireConsent = c.Boolean(false)
                })
                .PrimaryKey(t => t.ClientId);

            CreateTable(
                "dbo.OpenIdConnectClientsRedirectUris",
                c => new
                {
                    ID = c.Int(false, true),
                    RedirectUri = c.String(false),
                    OpenIdConnectClientEntity_ClientId = c.String(maxLength: 128)
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OpenIdConnectClients", t => t.OpenIdConnectClientEntity_ClientId)
                .Index(t => t.OpenIdConnectClientEntity_ClientId);
        }

        public override void Down()
        {
            DropIndex("dbo.OpenIdConnectClientsRedirectUris", new[] {"OpenIdConnectClientEntity_ClientId"});
            DropForeignKey("dbo.OpenIdConnectClientsRedirectUris", "OpenIdConnectClientEntity_ClientId",
                "dbo.OpenIdConnectClients");
            DropTable("dbo.OpenIdConnectClientsRedirectUris");
            DropTable("dbo.OpenIdConnectClients");
            DropTable("dbo.OpenIdConnectConfiguration");
        }
    }
}