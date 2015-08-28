using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlCe
{
    public partial class ClientSecretNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "ClientSecret", c => c.String(true, 4000));
        }

        public override void Down()
        {
            AlterColumn("dbo.Client", "ClientSecret", c => c.String(false, 4000));
        }
    }
}