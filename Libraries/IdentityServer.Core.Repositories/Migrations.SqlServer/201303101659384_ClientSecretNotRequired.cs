using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
{
    public partial class ClientSecretNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "ClientSecret", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Client", "ClientSecret", c => c.String(false));
        }
    }
}