// <auto-generated />
namespace IdentityServer.Core.Repositories.Migrations.SqlCe
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class DisableSSL : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(DisableSSL));
        
        string IMigrationMetadata.Id
        {
            get { return "201308171332371_DisableSSL"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}