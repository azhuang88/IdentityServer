/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using IdentityServer.Helper;
using IdentityServer.Models;
using IdentityServer.Repositories.Sql.Configuration;
using Thinktecture.IdentityModel;
using AdfsIntegrationConfiguration = IdentityServer.Models.Configuration.AdfsIntegrationConfiguration;
using DiagnosticsConfiguration = IdentityServer.Models.Configuration.DiagnosticsConfiguration;
using Entities = IdentityServer.Repositories.Sql;
using FederationMetadataConfiguration = IdentityServer.Models.Configuration.FederationMetadataConfiguration;
using GlobalConfiguration = IdentityServer.Models.Configuration.GlobalConfiguration;
using KeyMaterialConfiguration = IdentityServer.Models.Configuration.KeyMaterialConfiguration;
using OAuth2Configuration = IdentityServer.Models.Configuration.OAuth2Configuration;
using OpenIdConnectConfiguration = IdentityServer.Models.Configuration.OpenIdConnectConfiguration;
using SimpleHttpConfiguration = IdentityServer.Models.Configuration.SimpleHttpConfiguration;
using WSFederationConfiguration = IdentityServer.Models.Configuration.WSFederationConfiguration;
using WSTrustConfiguration = IdentityServer.Models.Configuration.WSTrustConfiguration;
using LdapConfiguration = IdentityServer.Models.Configuration.LdapConfiguration;

namespace IdentityServer.Repositories.Sql
{
    internal static class Mappings
    {
        #region Client Certificates

        public static List<ClientCertificate> ToDomainModel(this List<ClientCertificates> entities)
        {
            return
                (from entity in entities
                    select new ClientCertificate
                    {
                        UserName = entity.UserName,
                        Thumbprint = entity.Thumbprint,
                        Description = entity.Description
                    }
                    ).ToList();
        }

        #endregion

        #region Delegation

        public static List<DelegationSetting> ToDomainModel(this List<Delegation> entities)
        {
            return
                (from entity in entities
                    select new DelegationSetting
                    {
                        UserName = entity.UserName,
                        Realm = new Uri(entity.Realm),
                        Description = entity.Description
                    }
                    ).ToList();
        }

        #endregion

        #region CodeToken

        public static Models.CodeToken ToDomainModel(this CodeToken token)
        {
            return new Models.CodeToken
            {
                ClientId = token.ClientId,
                Scope = token.Scope,
                UserName = token.UserName,
                Code = token.Code,
                Type = (CodeTokenType) token.Type,
                TimeStamp = token.TimeStamp
            };
        }

        #endregion

        #region GlobalConfiguration

        public static GlobalConfiguration ToDomainModel(this Configuration.GlobalConfiguration entity)
        {
            return new GlobalConfiguration
            {
                SiteName = entity.SiteName,
                IssuerUri = entity.IssuerUri,
                IssuerContactEmail = entity.IssuerContactEmail,
                DefaultHttpTokenType = entity.DefaultHttpTokenType,
                DefaultWSTokenType = entity.DefaultWSTokenType,
                DefaultTokenLifetime = entity.DefaultTokenLifetime,
                MaximumTokenLifetime = entity.MaximumTokenLifetime,
                EnableClientCertificateAuthentication = entity.EnableClientCertificateAuthentication,
                EnforceUsersGroupMembership = entity.EnforceUsersGroupMembership,
                HttpPort = entity.HttpPort,
                DisableSSL = entity.DisableSSL,
                HttpsPort = entity.HttpsPort,
                PublicHostName = entity.PublicHostName,
                RequireEncryption = entity.RequireEncryption,
                RequireRelyingPartyRegistration = entity.RequireRelyingPartyRegistration,
                SsoCookieLifetime = entity.SsoCookieLifetime
            };
        }

        public static Configuration.GlobalConfiguration ToEntity(this GlobalConfiguration model)
        {
            return new Configuration.GlobalConfiguration
            {
                SiteName = model.SiteName,
                IssuerUri = model.IssuerUri,
                IssuerContactEmail = model.IssuerContactEmail,
                DefaultHttpTokenType = model.DefaultHttpTokenType,
                DefaultWSTokenType = model.DefaultWSTokenType,
                DefaultTokenLifetime = model.DefaultTokenLifetime,
                MaximumTokenLifetime = model.MaximumTokenLifetime,
                EnableClientCertificateAuthentication = model.EnableClientCertificateAuthentication,
                EnforceUsersGroupMembership = model.EnforceUsersGroupMembership,
                HttpPort = model.HttpPort,
                DisableSSL = model.DisableSSL,
                HttpsPort = model.HttpsPort,
                PublicHostName = model.PublicHostName,
                RequireEncryption = model.RequireEncryption,
                RequireRelyingPartyRegistration = model.RequireRelyingPartyRegistration,
                SsoCookieLifetime = model.SsoCookieLifetime
            };
        }

        #endregion


        #region WSFederationConfiguration

        public static WSFederationConfiguration ToDomainModel(this Configuration.WSFederationConfiguration entity)
        {
            return new WSFederationConfiguration
            {
                AllowReplyTo = entity.AllowReplyTo,
                EnableAuthentication = entity.EnableAuthentication,
                Enabled = entity.Enabled,
                EnableFederation = entity.EnableFederation,
                EnableHrd = entity.EnableHrd,
                RequireReplyToWithinRealm = entity.RequireReplyToWithinRealm,
                RequireSslForReplyTo = entity.RequireSslForReplyTo
            };
        }

        public static Configuration.WSFederationConfiguration ToEntity(this WSFederationConfiguration model)
        {
            return new Configuration.WSFederationConfiguration
            {
                AllowReplyTo = model.AllowReplyTo,
                EnableAuthentication = model.EnableAuthentication,
                Enabled = model.Enabled,
                EnableFederation = model.EnableFederation,
                EnableHrd = model.EnableHrd,
                RequireReplyToWithinRealm = model.RequireReplyToWithinRealm,
                RequireSslForReplyTo = model.RequireSslForReplyTo
            };
        }

        public static LdapConfiguration ToDomainModel(this Configuration.LdapConfiguration entity)
        {
            return new LdapConfiguration()
            {
                LdapConnectionString = entity.LdapConnectionString,
                Domain = entity.Domain,
                Enabled = entity.Enabled,
                SiteTitle = entity.SiteTitle
            };
        }

        public static Configuration.LdapConfiguration ToEntity(this LdapConfiguration model)
        {
            return new Configuration.LdapConfiguration()
            {
                LdapConnectionString = model.LdapConnectionString,
                Domain = model.Domain,
                Enabled = model.Enabled,
                SiteTitle = model.SiteTitle
            };
        }
        #endregion

        #region KeyMaterialConfiguration

        public static KeyMaterialConfiguration ToDomainModel(this Configuration.KeyMaterialConfiguration entity)
        {
            var model = new KeyMaterialConfiguration();
            if (entity == null)
            {
                return model;
            }

            if (!string.IsNullOrWhiteSpace(entity.SigningCertificateName))
            {
                var cert =
                    X509.LocalMachine.My.SubjectDistinguishedName.Find(entity.SigningCertificateName, false)
                        .FirstOrDefault();

                if (cert == null)
                {
                    throw new InvalidOperationException(
                        string.Format(Core.Repositories.Resources.Mappings.SigningCertificateNotFoundException,
                            entity.SigningCertificateName));
                }

                model.SigningCertificate = cert;
            }

            if (!string.IsNullOrWhiteSpace(entity.DecryptionCertificateName))
            {
                var cert =
                    X509.LocalMachine.My.SubjectDistinguishedName.Find(entity.DecryptionCertificateName, false)
                        .FirstOrDefault();

                if (cert == null)
                {
                    throw new InvalidOperationException(
                        string.Format(Core.Repositories.Resources.Mappings.DecryptionCertificateNotFoundException,
                            entity.DecryptionCertificateName));
                }

                model.DecryptionCertificate = cert;
            }
            else
            {
                model.DecryptionCertificate = null;
            }

            model.SymmetricSigningKey = entity.SymmetricSigningKey;

            return model;
        }

        public static Configuration.KeyMaterialConfiguration ToEntity(this KeyMaterialConfiguration model)
        {
            var entity = new Configuration.KeyMaterialConfiguration();

            if (model.SigningCertificate != null)
            {
                entity.SigningCertificateName = model.SigningCertificate.Subject;
            }

            if (model.DecryptionCertificate != null)
            {
                entity.DecryptionCertificateName = model.DecryptionCertificate.Subject;
            }
            else
            {
                entity.DecryptionCertificateName = null;
            }

            entity.SymmetricSigningKey = model.SymmetricSigningKey;

            return entity;
        }

        #endregion

        #region WSTrustConfiguration

        public static WSTrustConfiguration ToDomainModel(this Configuration.WSTrustConfiguration entity)
        {
            return new WSTrustConfiguration
            {
                EnableClientCertificateAuthentication = entity.EnableClientCertificateAuthentication,
                Enabled = entity.Enabled,
                EnableDelegation = entity.EnableDelegation,
                EnableFederatedAuthentication = entity.EnableFederatedAuthentication,
                EnableMessageSecurity = entity.EnableMessageSecurity,
                EnableMixedModeSecurity = entity.EnableMixedModeSecurity
            };
        }

        public static Configuration.WSTrustConfiguration ToEntity(this WSTrustConfiguration model)
        {
            return new Configuration.WSTrustConfiguration
            {
                EnableClientCertificateAuthentication = model.EnableClientCertificateAuthentication,
                Enabled = model.Enabled,
                EnableDelegation = model.EnableDelegation,
                EnableFederatedAuthentication = model.EnableFederatedAuthentication,
                EnableMessageSecurity = model.EnableMessageSecurity,
                EnableMixedModeSecurity = model.EnableMixedModeSecurity
            };
        }

        #endregion

        #region FederationMetadataConfiguration

        public static FederationMetadataConfiguration ToDomainModel(
            this Configuration.FederationMetadataConfiguration entity)
        {
            return new FederationMetadataConfiguration
            {
                Enabled = entity.Enabled
            };
        }

        public static Configuration.FederationMetadataConfiguration ToEntity(this FederationMetadataConfiguration model)
        {
            return new Configuration.FederationMetadataConfiguration
            {
                Enabled = model.Enabled
            };
        }

        #endregion

        #region OAuth2Configuration

        public static OAuth2Configuration ToDomainModel(this Configuration.OAuth2Configuration entity)
        {
            return new OAuth2Configuration
            {
                Enabled = entity.Enabled,
                EnableImplicitFlow = entity.EnableImplicitFlow,
                EnableResourceOwnerFlow = entity.EnableResourceOwnerFlow,
                EnableConsent = entity.EnableConsent,
                EnableCodeFlow = entity.EnableCodeFlow
            };
        }

        public static Configuration.OAuth2Configuration ToEntity(this OAuth2Configuration model)
        {
            return new Configuration.OAuth2Configuration
            {
                Enabled = model.Enabled,
                EnableImplicitFlow = model.EnableImplicitFlow,
                EnableResourceOwnerFlow = model.EnableResourceOwnerFlow,
                EnableConsent = model.EnableConsent,
                EnableCodeFlow = model.EnableCodeFlow
            };
        }

        #endregion

        #region AdfsIntegrationConfiguration

        public static AdfsIntegrationConfiguration ToDomainModel(this Configuration.AdfsIntegrationConfiguration entity)
        {
            var value = new AdfsIntegrationConfiguration
            {
                Enabled = entity.Enabled,
                UsernameAuthenticationEnabled = entity.UsernameAuthenticationEnabled,
                SamlAuthenticationEnabled = entity.SamlAuthenticationEnabled,
                JwtAuthenticationEnabled = entity.JwtAuthenticationEnabled,
                PassThruAuthenticationToken = entity.PassThruAuthenticationToken,
                AuthenticationTokenLifetime = entity.AuthenticationTokenLifetime,
                UserNameAuthenticationEndpoint = entity.UserNameAuthenticationEndpoint,
                FederationEndpoint = entity.FederationEndpoint,
                IssuerThumbprint = entity.IssuerThumbprint,
                IssuerUri = entity.IssuerUri
            };

            if (!string.IsNullOrWhiteSpace(entity.EncryptionCertificate))
            {
                value.EncryptionCertificate =
                    new X509Certificate2(Convert.FromBase64String(entity.EncryptionCertificate));
            }
            else
            {
                value.EncryptionCertificate = null;
            }

            return value;
        }

        public static Configuration.AdfsIntegrationConfiguration ToEntity(this AdfsIntegrationConfiguration model)
        {
            var value = new Configuration.AdfsIntegrationConfiguration
            {
                Enabled = model.Enabled,
                UsernameAuthenticationEnabled = model.UsernameAuthenticationEnabled,
                SamlAuthenticationEnabled = model.SamlAuthenticationEnabled,
                JwtAuthenticationEnabled = model.JwtAuthenticationEnabled,
                PassThruAuthenticationToken = model.PassThruAuthenticationToken,
                AuthenticationTokenLifetime = model.AuthenticationTokenLifetime,
                UserNameAuthenticationEndpoint = model.UserNameAuthenticationEndpoint,
                FederationEndpoint = model.FederationEndpoint,
                IssuerThumbprint = model.IssuerThumbprint,
                IssuerUri = model.IssuerUri
            };

            if (model.EncryptionCertificate != null)
            {
                value.EncryptionCertificate = Convert.ToBase64String(model.EncryptionCertificate.RawData);
            }
            else
            {
                value.EncryptionCertificate = null;
            }

            return value;
        }

        #endregion

        #region SimpleHttpConfiguration

        public static SimpleHttpConfiguration ToDomainModel(this Configuration.SimpleHttpConfiguration entity)
        {
            return new SimpleHttpConfiguration
            {
                Enabled = entity.Enabled
            };
        }

        public static Configuration.SimpleHttpConfiguration ToEntity(this SimpleHttpConfiguration model)
        {
            return new Configuration.SimpleHttpConfiguration
            {
                Enabled = model.Enabled
            };
        }

        #endregion

        #region DiagnosticsConfiguration

        public static DiagnosticsConfiguration ToDomainModel(this Configuration.DiagnosticsConfiguration entity)
        {
            return new DiagnosticsConfiguration
            {
                EnableFederationMessageTracing = entity.EnableFederationMessageTracing
            };
        }

        public static Configuration.DiagnosticsConfiguration ToEntity(this DiagnosticsConfiguration model)
        {
            return new Configuration.DiagnosticsConfiguration
            {
                EnableFederationMessageTracing = model.EnableFederationMessageTracing
            };
        }

        #endregion

        #region Relying Party

        public static RelyingParty ToDomainModel(this RelyingParties rpEntity)
        {
            var rp = new RelyingParty
            {
                Id = rpEntity.Id.ToString(),
                Name = rpEntity.Name,
                Enabled = rpEntity.Enabled,
                TokenType = rpEntity.TokenType,
                TokenLifeTime = rpEntity.TokenLifeTime,
                Realm = new Uri(rpEntity.Realm),
                ExtraData1 = rpEntity.ExtraData1,
                ExtraData2 = rpEntity.ExtraData2,
                ExtraData3 = rpEntity.ExtraData3
            };

            if (!string.IsNullOrWhiteSpace(rpEntity.ReplyTo))
            {
                rp.ReplyTo = new Uri(rpEntity.ReplyTo);
            }

            if (!string.IsNullOrWhiteSpace(rpEntity.EncryptingCertificate))
            {
                rp.EncryptingCertificate = new X509Certificate2(Convert.FromBase64String(rpEntity.EncryptingCertificate));
            }

            if (!string.IsNullOrWhiteSpace(rpEntity.SymmetricSigningKey))
            {
                rp.SymmetricSigningKey = Convert.FromBase64String(rpEntity.SymmetricSigningKey);
            }

            return rp;
        }

        public static RelyingParties ToEntity(this RelyingParty relyingParty)
        {
            var rpEntity = new RelyingParties
            {
                Name = relyingParty.Name,
                Enabled = relyingParty.Enabled,
                Realm = relyingParty.Realm.AbsoluteUri,
                TokenType = relyingParty.TokenType,
                TokenLifeTime = relyingParty.TokenLifeTime,
                ExtraData1 = relyingParty.ExtraData1,
                ExtraData2 = relyingParty.ExtraData2,
                ExtraData3 = relyingParty.ExtraData3
            };

            if (!string.IsNullOrEmpty(relyingParty.Id))
            {
                rpEntity.Id = int.Parse(relyingParty.Id);
            }

            if (relyingParty.ReplyTo != null)
            {
                rpEntity.ReplyTo = relyingParty.ReplyTo.AbsoluteUri;
            }

            if (relyingParty.EncryptingCertificate != null)
            {
                rpEntity.EncryptingCertificate = Convert.ToBase64String(relyingParty.EncryptingCertificate.RawData);
            }

            if (relyingParty.SymmetricSigningKey != null && relyingParty.SymmetricSigningKey.Length != 0)
            {
                rpEntity.SymmetricSigningKey = Convert.ToBase64String(relyingParty.SymmetricSigningKey);
            }

            return rpEntity;
        }

        public static IEnumerable<RelyingParty> ToDomainModel(this List<RelyingParties> relyingParties)
        {
            return
                (from rp in relyingParties
                    select new RelyingParty
                    {
                        Id = rp.Id.ToString(),
                        Name = rp.Name,
                        Realm = new Uri(rp.Realm),
                        Enabled = rp.Enabled
                    }).ToList();
        }

        #endregion

        #region Clients

        public static Models.Client ToDomainModel(this Client client)
        {
            return new Models.Client
            {
                ID = client.Id,
                ClientId = client.ClientId,
                //ClientSecret = client.ClientSecret,
                HasClientSecret = !string.IsNullOrWhiteSpace(client.ClientSecret),
                Description = client.Description,
                Name = client.Name,
                RedirectUri = client.RedirectUri != null ? new Uri(client.RedirectUri) : null,
                AllowRefreshToken = client.AllowRefreshToken,
                AllowCodeFlow = client.AllowCodeFlow,
                AllowImplicitFlow = client.AllowImplicitFlow,
                AllowResourceOwnerFlow = client.AllowResourceOwnerFlow
            };
        }

        public static void UpdateEntity(this Models.Client client, Client target)
        {
            target.Id = client.ID;
            target.ClientId = client.ClientId;
            if (!string.IsNullOrWhiteSpace(client.ClientSecret))
            {
                target.ClientSecret = CryptoHelper.HashPassword(client.ClientSecret);
            }
            target.Description = client.Description;
            target.Name = client.Name;
            target.RedirectUri = client.RedirectUri != null ? client.RedirectUri.AbsoluteUri : null;
            target.AllowRefreshToken = client.AllowRefreshToken;
            target.AllowResourceOwnerFlow = client.AllowResourceOwnerFlow;
            target.AllowImplicitFlow = client.AllowImplicitFlow;
            target.AllowCodeFlow = client.AllowCodeFlow;
        }

        #endregion

        #region IdentityProvider

        public static List<Models.IdentityProvider> ToDomainModel(this List<IdentityProvider> idps)
        {
            return new List<Models.IdentityProvider>(
                from idp in idps
                select new Models.IdentityProvider
                {
                    ID = idp.ID,
                    Name = idp.Name,
                    Enabled = idp.Enabled,
                    DisplayName = idp.DisplayName,
                    Type = (IdentityProviderTypes) idp.Type,
                    ShowInHrdSelection = idp.ShowInHrdSelection,
                    WSFederationEndpoint = idp.WSFederationEndpoint,
                    IssuerThumbprint = idp.IssuerThumbprint,
                    ClientID = idp.ClientID,
                    ClientSecret = idp.ClientSecret,
                    ProviderType = (OAuth2ProviderTypes?) idp.OAuth2ProviderType
                });
        }

        public static Models.IdentityProvider ToDomainModel(this IdentityProvider idp)
        {
            if (idp == null)
            {
                return null;
            }

            return new Models.IdentityProvider
            {
                ID = idp.ID,
                Name = idp.Name,
                Enabled = idp.Enabled,
                DisplayName = idp.DisplayName,
                ShowInHrdSelection = idp.ShowInHrdSelection,
                Type = (IdentityProviderTypes) idp.Type,
                WSFederationEndpoint = idp.WSFederationEndpoint,
                IssuerThumbprint = idp.IssuerThumbprint,
                ClientID = idp.ClientID,
                ClientSecret = idp.ClientSecret,
                ProviderType = (OAuth2ProviderTypes?) idp.OAuth2ProviderType
            };
        }

        public static IdentityProvider ToEntity(this Models.IdentityProvider idp)
        {
            if (idp == null)
            {
                return null;
            }

            var entity = new IdentityProvider();
            idp.UpdateEntity(entity);
            return entity;
        }

        public static void UpdateEntity(this Models.IdentityProvider idp, IdentityProvider entity)
        {
            if (idp == null || entity == null)
            {
                return;
            }

            entity.ID = idp.ID;
            entity.Name = idp.Name;
            entity.Enabled = idp.Enabled;
            entity.ShowInHrdSelection = idp.ShowInHrdSelection;
            entity.DisplayName = idp.DisplayName;
            entity.Type = (int) idp.Type;
            entity.WSFederationEndpoint = idp.WSFederationEndpoint;
            entity.IssuerThumbprint = idp.IssuerThumbprint;
            entity.ClientID = idp.ClientID;
            entity.ClientSecret = idp.ClientSecret;
            entity.OAuth2ProviderType = (int?) idp.ProviderType;
        }

        #endregion

        #region StoredGrant

        public static StoredGrant ToEntityModel(this Models.StoredGrant grant)
        {
            return new StoredGrant
            {
                ClientId = grant.ClientId,
                Created = grant.Created,
                Expiration = grant.Expiration,
                GrantId = grant.GrantId,
                GrantType = (int) grant.GrantType,
                RedirectUri = grant.RedirectUri,
                RefreshTokenExpiration = grant.RefreshTokenExpiration,
                Scopes = grant.Scopes,
                Subject = grant.Subject
            };
        }

        public static Models.StoredGrant ToDomainModel(this StoredGrant grant)
        {
            return new Models.StoredGrant
            {
                ClientId = grant.ClientId,
                Created = grant.Created,
                Expiration = grant.Expiration,
                GrantId = grant.GrantId,
                GrantType = (StoredGrantType) grant.GrantType,
                RedirectUri = grant.RedirectUri,
                RefreshTokenExpiration = grant.RefreshTokenExpiration,
                Scopes = grant.Scopes,
                Subject = grant.Subject
            };
        }

        #endregion

        #region OpenIdConnectConfiguration

        public static OpenIdConnectConfiguration ToDomainModel(this Configuration.OpenIdConnectConfiguration entity)
        {
            var value = new OpenIdConnectConfiguration
            {
                Enabled = entity.Enabled
            };

            return value;
        }

        public static Configuration.OpenIdConnectConfiguration ToEntity(this OpenIdConnectConfiguration model)
        {
            var value = new Configuration.OpenIdConnectConfiguration
            {
                Enabled = model.Enabled
            };

            return value;
        }

        #endregion

        #region OpenIdConnectClients

        public static OpenIdConnectClient ToDomainModel(this OpenIdConnectClientEntity client)
        {
            var ret = new OpenIdConnectClient
            {
                ClientId = client.ClientId,
                AccessTokenLifetime = client.AccessTokenLifetime,
                AllowRefreshToken = client.AllowRefreshToken,
                ClientSecretType = client.ClientSecretType,
                Flow = client.Flow,
                Name = client.Name,
                RefreshTokenLifetime = client.RefreshTokenLifetime,
                RequireConsent = client.RequireConsent
            };

            if (client.RedirectUris != null)
            {
                ret.RedirectUris =
                    (from item in client.RedirectUris
                        select item.RedirectUri).ToArray();
            }
            else
            {
                ret.RedirectUris = new string[0];
            }

            return ret;
        }

        public static void UpdateEntity(this OpenIdConnectClient client, OpenIdConnectClientEntity target)
        {
            target.ClientId = client.ClientId;
            target.AccessTokenLifetime = client.AccessTokenLifetime;
            target.AllowRefreshToken = client.AllowRefreshToken;
            target.ClientSecretType = client.ClientSecretType;
            target.Flow = client.Flow;
            target.Name = client.Name;
            target.RefreshTokenLifetime = client.RefreshTokenLifetime;
            target.RequireConsent = client.RequireConsent;

            if (!string.IsNullOrWhiteSpace(client.ClientSecret))
            {
                target.ClientSecret = CryptoHelper.HashPassword(client.ClientSecret);
            }

            if (client.RedirectUris != null)
            {
                var urlsToRemove =
                    target.RedirectUris.Where(x => !client.RedirectUris.Contains(x.RedirectUri)).ToArray();
                foreach (var remove in urlsToRemove)
                {
                    target.RedirectUris.Remove(remove);
                }
            }

            if (client.RedirectUris != null)
            {
                var urlsToAdd = target.RedirectUris != null
                    ? client.RedirectUris.Where(x => !target.RedirectUris.Any(y => y.RedirectUri == x)).ToArray()
                    : client.RedirectUris;
                foreach (var add in urlsToAdd)
                {
                    target.RedirectUris.Add(new OpenIdConnectClientRedirectUri {RedirectUri = add});
                }
            }
        }

        #endregion
    }
}