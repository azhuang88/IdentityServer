using System.Data.Entity.Migrations;

namespace IdentityServer.Core.Repositories.Migrations.SqlCe
{
    public partial class RPTokenType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RelyingParties", "TokenType", c => c.Int(true));
        }

        public override void Down()
        {
            DropColumn("dbo.RelyingParties", "TokenType");
        }
    }
}