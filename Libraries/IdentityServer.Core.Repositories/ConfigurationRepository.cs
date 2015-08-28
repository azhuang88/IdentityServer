using System.Linq;
using IdentityServer.Models.Configuration;
using Entities = IdentityServer.Repositories.Sql;

namespace IdentityServer.Repositories.Sql
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public virtual bool SupportsWriteAccess
        {
            get { return true; }
        }

        public virtual GlobalConfiguration Global
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.GlobalConfiguration.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.GlobalConfiguration.First();
                    entities.GlobalConfiguration.Remove(entity);

                    entities.GlobalConfiguration.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual DiagnosticsConfiguration Diagnostics
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.Diagnostics.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.Diagnostics.First();
                    entities.Diagnostics.Remove(entity);

                    entities.Diagnostics.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual KeyMaterialConfiguration Keys
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.Keys.FirstOrDefault();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.Keys.FirstOrDefault();

                    if (entity != null)
                    {
                        entities.Keys.Remove(entity);
                    }

                    entities.Keys.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual WSFederationConfiguration WSFederation
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.WSFederation.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.WSFederation.First();
                    entities.WSFederation.Remove(entity);

                    entities.WSFederation.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual LdapConfiguration LdapConfiguration
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.Ldap.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.Ldap.First();
                    entities.Ldap.Remove(entity);

                    entities.Ldap.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual FederationMetadataConfiguration FederationMetadata
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.FederationMetadata.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.FederationMetadata.First();
                    entities.FederationMetadata.Remove(entity);

                    entities.FederationMetadata.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual WSTrustConfiguration WSTrust
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.WSTrust.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.WSTrust.First();
                    entities.WSTrust.Remove(entity);

                    entities.WSTrust.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual OAuth2Configuration OAuth2
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.OAuth2.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.OAuth2.First();
                    entities.OAuth2.Remove(entity);

                    entities.OAuth2.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public virtual SimpleHttpConfiguration SimpleHttp
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.SimpleHttp.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.SimpleHttp.First();
                    entities.SimpleHttp.Remove(entity);

                    entities.SimpleHttp.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        // todo: wire up with DB
        public AdfsIntegrationConfiguration AdfsIntegration
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.AdfsIntegration.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.AdfsIntegration.First();
                    entities.AdfsIntegration.Remove(entity);

                    entities.AdfsIntegration.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }

        public OpenIdConnectConfiguration OpenIdConnect
        {
            get
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.OpenIdConnect.First();
                    return entity.ToDomainModel();
                }
            }
            set
            {
                using (var entities = IdentityServerConfigurationContext.Get())
                {
                    var entity = entities.OpenIdConnect.First();
                    entities.OpenIdConnect.Remove(entity);

                    entities.OpenIdConnect.Add(value.ToEntity());
                    entities.SaveChanges();
                }
            }
        }
    }
}