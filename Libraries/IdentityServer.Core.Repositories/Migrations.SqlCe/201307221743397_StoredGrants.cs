using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlCe
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
                    GrantId = c.String(false, 4000),
                    GrantType = c.Int(false),
                    Subject = c.String(false, 4000),
                    Scopes = c.String(false, 4000),
                    ClientId = c.String(false, 4000),
                    Created = c.DateTime(false),
                    Expiration = c.DateTime(false),
                    RefreshTokenExpiration = c.DateTime(),
                    RedirectUri = c.String(maxLength: 4000)
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.StoredGrant");
        }
    }
}