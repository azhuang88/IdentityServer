using System.Data.Entity.Migrations;
using IdentityServer.Repositories.Sql;

namespace IdentityServer.Core.Repositories.Migrations.SqlServer
{
    internal sealed class SqlServerConfiguration : DbMigrationsConfiguration<IdentityServerConfigurationContext>
    {
        public SqlServerConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentityServerConfigurationContext context)
        {
            //  This method will be called after migrating to the latest version.
            ConfigurationDatabaseInitializer.SeedContext(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}