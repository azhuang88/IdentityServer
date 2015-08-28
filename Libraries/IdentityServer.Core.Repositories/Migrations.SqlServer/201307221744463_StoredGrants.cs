using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
{
    public partial class StoredGrants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoredGrant",
                c => new
                {
                    Id = c.Int(false, true),
                    GrantId = c.String(false),
                    GrantType = c.Int(false),
                    Subject = c.String(false),
                    Scopes = c.String(false),
                    ClientId = c.String(false),
                    Created = c.DateTime(false),
                    Expiration = c.DateTime(false),
                    RefreshTokenExpiration = c.DateTime(),
                    RedirectUri = c.String()
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.StoredGrant");
        }
    }
}