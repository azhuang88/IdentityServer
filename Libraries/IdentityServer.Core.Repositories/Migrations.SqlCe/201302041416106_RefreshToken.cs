using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlCe
{
    public partial class RefreshToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeToken",
                c => new
                {
                    Id = c.Int(false, true),
                    Code = c.String(maxLength: 4000),
                    ClientId = c.Int(false),
                    UserName = c.String(maxLength: 4000),
                    Scope = c.String(maxLength: 4000),
                    Type = c.Int(false),
                    TimeStamp = c.DateTime(false)
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.OAuth2Configuration", "EnableCodeFlow", c => c.Boolean(false));
            AddColumn("dbo.Client", "AllowRefreshToken", c => c.Boolean(false));
            DropColumn("dbo.Client", "NativeClient");
        }

        public override void Down()
        {
            AddColumn("dbo.Client", "NativeClient", c => c.Boolean(false));
            DropColumn("dbo.Client", "AllowRefreshToken");
            DropColumn("dbo.OAuth2Configuration", "EnableCodeFlow");
            DropTable("dbo.CodeToken");
        }
    }
}