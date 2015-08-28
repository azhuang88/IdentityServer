/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models.Configuration
{
    public class OAuth2Configuration : ProtocolConfiguration
    {
        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.OAuth2Configuration), Name = "EnableImplicitFlow",
            Description = "EnableImplicitFlowDescription")]
        public bool EnableImplicitFlow { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.OAuth2Configuration),
            Name = "EnableResourceOwnerFlow", Description = "EnableResourceOwnerFlowDescription")]
        public bool EnableResourceOwnerFlow { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.OAuth2Configuration), Name = "EnableCodeFlow",
            Description = "EnableCodeFlowDescription")]
        public bool EnableCodeFlow { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.OAuth2Configuration), Name = "EnableConsent",
            Description = "EnableConsentDescription")]
        public bool EnableConsent { get; set; }
    }
}