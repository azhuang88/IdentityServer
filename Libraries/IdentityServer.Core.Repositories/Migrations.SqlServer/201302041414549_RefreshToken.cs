using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
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
                    Code = c.String(),
                    ClientId = c.Int(false),
                    UserName = c.String(),
                    Scope = c.String(),
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