/*
 * Copyright (c) Alexander Zhuang .  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class Client : IValidatableObject
    {
        [UIHint("HiddenInput")]
        public int ID { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "Name", Description = "NameDescription")]
        [Required]
        public string Name { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "Description",
            Description = "DescriptionDescription")]
        [Required]
        public string Description { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "ClientId", Description = "ClientIdDescription"
            )]
        [Required]
        public string ClientId { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "ClientSecret",
            Description = "ClientSecretDescription")]
        [UIHint("SymmetricKey")]
        public string ClientSecret { get; set; }

        [UIHint("HiddenInput")]
        public bool HasClientSecret { get; set; }

        [AbsoluteUri]
        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "RedirectUri",
            Description = "RedirectUriDescription")]
        public Uri RedirectUri { get; set; }

        //[Display(Name = "Native Client", Description = "Native Client.")]
        //[UIHint("HiddenInput")]
        //public bool NativeClient { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "AllowImplicitFlow",
            Description = "AllowImplicitFlowDescription")]
        public bool AllowImplicitFlow { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "AllowResourceOwnerFlow",
            Description = "AllowResourceOwnerFlowDescription")]
        public bool AllowResourceOwnerFlow { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "AllowCodeFlow",
            Description = "AllowCodeFlowDescription")]
        public bool AllowCodeFlow { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Client), Name = "AllowRefreshToken",
            Description = "AllowRefreshTokenDescription")]
        public bool AllowRefreshToken { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!HasClientSecret &&
                string.IsNullOrWhiteSpace(ClientSecret) &&
                (AllowCodeFlow || AllowResourceOwnerFlow))
            {
                errors.Add(new ValidationResult(Core.Resources.Models.Client.ClientSecretRequiredError,
                    new[] {"ClientSecret"}));
            }

            if (RedirectUri == null &&
                (AllowCodeFlow || AllowImplicitFlow))
            {
                errors.Add(new ValidationResult(Core.Resources.Models.Client.RedirectUriRequiredError, new[] {"RedirectUri"}));
            }

            if (RedirectUri != null && RedirectUri.Scheme == Uri.UriSchemeHttp)
            {
                errors.Add(new ValidationResult(Core.Resources.Models.Client.RedirectUriMustBeHTTPS, new[] {"RedirectUri"}));
            }

            if (!AllowCodeFlow && !AllowResourceOwnerFlow && AllowRefreshToken)
            {
                errors.Add(new ValidationResult("Refresh tokens only allowed with Code or Resource Owner flows.",
                    new[] {"AllowRefreshToken"}));
            }

            return errors;
        }
    }
}