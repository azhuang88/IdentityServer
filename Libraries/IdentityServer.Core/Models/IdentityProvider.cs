/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class IdentityProvider : IValidatableObject
    {
        private string _IssuerThumbprint;

        [UIHint("HiddenInput")]
        public int ID { get; set; }

        [Required]
        [Display(Order = 1, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "Name",
            Description = "NameDescription")]
        public string Name { get; set; }

        [Required]
        [Display(Order = 2, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "DisplayName",
            Description = "DisplayNameDescription")]
        public string DisplayName { get; set; }

        [Display(Order = 3, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "Enabled",
            Description = "EnabledDescription")]
        public bool Enabled { get; set; }

        [Display(Order = 4, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "ShowInHrdSelection",
            Description = "ShowInHrdSelectionDescription")]
        public bool ShowInHrdSelection { get; set; }

        [Required]
        [UIHint("Enum")]
        [Display(Order = 5, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "Type",
            Description = "TypeDescription")]
        public IdentityProviderTypes Type { get; set; }

        [Display(Order = 6, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "WSFederationEndpoint",
            Description = "WSFederationEndpointDescription")]
        [AbsoluteUri]
        public string WSFederationEndpoint { get; set; }

        [UIHint("Thumbprint")]
        [Display(Order = 7, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "IssuerThumbprint",
            Description = "IssuerThumbprintDescription")]
        public string IssuerThumbprint
        {
            get { return _IssuerThumbprint; }
            set
            {
                _IssuerThumbprint = value;
                if (_IssuerThumbprint != null) _IssuerThumbprint = _IssuerThumbprint.Replace(" ", "");
            }
        }

        [Display(Order = 8, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "ProviderType",
            Description = "ProviderTypeDescription")]
        [UIHint("Enum")]
        public OAuth2ProviderTypes? ProviderType { get; set; }

        [Display(Order = 9, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "ClientID",
            Description = "ClientIDDescription")]
        public string ClientID { get; set; }

        [Display(Order = 10, ResourceType = typeof (Core.Resources.Models.IdentityProvider), Name = "ClientSecret",
            Description = "ClientSecretDescription")]
        public string ClientSecret { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Type == IdentityProviderTypes.WSStar)
            {
                if (string.IsNullOrEmpty(WSFederationEndpoint))
                {
                    errors.Add(new ValidationResult(
                        Core.Resources.Models.IdentityProvider.WSFederationEndpointRequiredError,
                        new[] {"WSFederationEndpoint"}));
                }
                if (string.IsNullOrEmpty(IssuerThumbprint))
                {
                    errors.Add(new ValidationResult(Core.Resources.Models.IdentityProvider.IssuerThumbprintRequiredError,
                        new[] {"IssuerThumbprint"}));
                }
            }
            if (Type == IdentityProviderTypes.OAuth2)
            {
                if (string.IsNullOrEmpty(ClientID))
                {
                    errors.Add(new ValidationResult(Core.Resources.Models.IdentityProvider.ClientIDRequiredError,
                        new[] {"ClientID"}));
                }
                if (string.IsNullOrEmpty(ClientSecret))
                {
                    errors.Add(new ValidationResult(Core.Resources.Models.IdentityProvider.ClientSecretRequiredError,
                        new[] {"ClientSecret"}));
                }
                if (ProviderType == null)
                {
                    errors.Add(new ValidationResult(Core.Resources.Models.IdentityProvider.ProviderTypeRequiredError,
                        new[] {"ProfileType"}));
                }
            }

            return errors;
        }
    }
}