/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Configuration;

namespace IdentityServer.Configuration
{
    /// <summary>
    ///     The StarterTokenServiceSection Configuration Section.
    /// </summary>
    public class RepositoryConfigurationSection : ConfigurationSection
    {
        public const string SectionName = "identityServer.repositories";

        #region TokenServiceConfiguration Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string TokenServiceConfigurationPropertyName = "tokenServiceConfiguration";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(TokenServiceConfigurationPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.Sql.ConfigurationRepository, IdentityServer.Core.Repositories")]
        public string TokenServiceConfiguration
        {
            get { return (string) base[TokenServiceConfigurationPropertyName]; }
            set { base[TokenServiceConfigurationPropertyName] = value; }
        }

        #endregion

        #region UserManagement Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string UserManagementPropertyName = "userManagement";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(UserManagementPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue =
                "IdentityServer.Repositories.ProviderUserManagementRepository, IdentityServer.Core.Repositories")]
        public string UserManagement
        {
            get { return (string) base[UserManagementPropertyName]; }
            set { base[UserManagementPropertyName] = value; }
        }

        #endregion

        #region UserValidation Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string UserValidationPropertyName = "userValidation";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(UserValidationPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.ProviderUserRepository, IdentityServer.Core.Repositories")]
        public string UserValidation
        {
            get { return (string) base[UserValidationPropertyName]; }
            set { base[UserValidationPropertyName] = value; }
        }

        #endregion

        #region ClaimsRepository Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string ClaimsRepositoryPropertyName = "claimsRepository";

        [ConfigurationProperty(ClaimsRepositoryPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.ProviderClaimsRepository, IdentityServer.Core.Repositories")]
        public string ClaimsRepository
        {
            get { return (string) base[ClaimsRepositoryPropertyName]; }
            set { base[ClaimsRepositoryPropertyName] = value; }
        }

        #endregion

        #region ClaimsTransformationRulesRepository Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string ClaimsTransformationRulesRepositoryPropertyName = "claimsTransformationRules";

        [ConfigurationProperty(ClaimsTransformationRulesRepositoryPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue =
                "IdentityServer.Repositories.PassThruTransformationRuleRepository, IdentityServer.Core.Repositories")]
        public string ClaimsTransformationRules
        {
            get { return (string) base[ClaimsTransformationRulesRepositoryPropertyName]; }
            set { base[ClaimsTransformationRulesRepositoryPropertyName] = value; }
        }

        #endregion

        #region RelyingParties Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string RelyingPartiesPropertyName = "relyingParties";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(RelyingPartiesPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.Sql.RelyingPartyRepository, IdentityServer.Core.Repositories")]
        public string RelyingParties
        {
            get { return (string) base[RelyingPartiesPropertyName]; }
            set { base[RelyingPartiesPropertyName] = value; }
        }

        #endregion

        #region ClientCertificates Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string ClientCertificatesPropertyName = "clientCertificates";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(ClientCertificatesPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue =
                "IdentityServer.Repositories.Sql.ClientCertificatesRepository, IdentityServer.Core.Repositories")]
        public string ClientCertificates
        {
            get { return (string) base[ClientCertificatesPropertyName]; }
            set { base[ClientCertificatesPropertyName] = value; }
        }

        #endregion

        #region ClientsRepository Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string ClientsRepositoryPropertyName = "clientsRepository";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(ClientsRepositoryPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue =
                "IdentityServer.Repositories.Sql.ClientCertificatesRepository, IdentityServer.Core.Repositories")]
        public string ClientsRepository
        {
            get { return (string) base[ClientsRepositoryPropertyName]; }
            set { base[ClientsRepositoryPropertyName] = value; }
        }

        #endregion

        #region OpenIdConnectClientsRepository Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string OpenIdConnectClientsRepositoryPropertyName = "openIdConnectClientsRepository";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(OpenIdConnectClientsRepositoryPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue =
                "IdentityServer.Repositories.Sql.OpenIdConnectClientsRepository, IdentityServer.Core.Repositories")]
        public string OpenIdConnectClientsRepository
        {
            get { return (string) base[OpenIdConnectClientsRepositoryPropertyName]; }
            set { base[OpenIdConnectClientsRepositoryPropertyName] = value; }
        }

        #endregion

        #region CodeTokenRepository Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string CodeTokenRepositoryPropertyName = "codeTokenRepository";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(CodeTokenRepositoryPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.Sql.RefreshTokenRepository, IdentityServer.Core.Repositories")]
        public string CodeTokenRepository
        {
            get { return (string) base[CodeTokenRepositoryPropertyName]; }
            set { base[CodeTokenRepositoryPropertyName] = value; }
        }

        #endregion

        #region StoredGrantRepository Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string StoredGrantRepositoryPropertyName = "storedGrantRepository";

        [ConfigurationProperty(StoredGrantRepositoryPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.Sql.StoredGrantRepository, IdentityServer.Core.Repositories")]
        public string StoredGrantRepository
        {
            get { return (string) base[StoredGrantRepositoryPropertyName]; }
            set { base[StoredGrantRepositoryPropertyName] = value; }
        }

        #endregion

        #region IdentityProvider Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string IdentityProviderPropertyName = "identityProvider";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(IdentityProviderPropertyName, IsRequired = false, IsKey = false,
            IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.Sql.IdentityProviderRepository, IdentityServer")]
        public string IdentityProvider
        {
            get { return (string) base[IdentityProviderPropertyName]; }
            set { base[IdentityProviderPropertyName] = value; }
        }

        #endregion

        #region Delegation Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string DelegationPropertyName = "delegation";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(DelegationPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.Sql.DelegationRepository, IdentityServer.Core.Repositories")]
        public string Delegation
        {
            get { return (string) base[DelegationPropertyName]; }
            set { base[DelegationPropertyName] = value; }
        }

        #endregion

        #region Caching Property

        /// <summary>
        ///     The XML name of the <see cref="ConfigurationProvider" /> property.
        /// </summary>
        internal const string CachingPropertyName = "caching";

        /// <summary>
        ///     Gets or sets type of the class that provides encryption certificates
        /// </summary>
        [ConfigurationProperty(CachingPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false,
            DefaultValue = "IdentityServer.Repositories.MemoryCacheRepository, IdentityServer.Core.Repositories")]
        public string Caching
        {
            get { return (string) base[CachingPropertyName]; }
            set { base[CachingPropertyName] = value; }
        }

        #endregion

        #region Xmlns Property

        /// <summary>
        ///     The XML name of the <see cref="Xmlns" /> property.
        /// </summary>
        internal const string XmlnsPropertyName = "xmlns";

        /// <summary>
        ///     Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        ///     This property makes sure that if the configuration file contains the XML namespace,
        ///     the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [ConfigurationProperty(XmlnsPropertyName, IsRequired = false, IsKey = false, IsDefaultCollection = false)]
        public string Xmlns
        {
            get { return (string) base[XmlnsPropertyName]; }
        }

        #endregion
    }
}