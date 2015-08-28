using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
{
    public partial class DisableSSL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GlobalConfiguration", "DisableSSL", c => c.Boolean(false));
            AddColumn("dbo.GlobalConfiguration", "PublicHostName", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.GlobalConfiguration", "PublicHostName");
            DropColumn("dbo.GlobalConfiguration", "DisableSSL");
        }
    }
}