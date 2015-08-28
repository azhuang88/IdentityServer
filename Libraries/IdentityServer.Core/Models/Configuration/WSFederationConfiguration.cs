/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models.Configuration
{
    public class WSFederationConfiguration : ProtocolConfiguration
    {
        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSFederationConfiguration),
            Name = "EnableAuthentication", Description = "EnableAuthenticationDescription")]
        public bool EnableAuthentication { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSFederationConfiguration),
            Name = "EnableFederation", Description = "EnableFederationDescription")]
        public bool EnableFederation { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSFederationConfiguration), Name = "EnableHrd",
            Description = "EnableHrdDescription")]
        public bool EnableHrd { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSFederationConfiguration), Name = "AllowReplyTo",
            Description = "AllowReplyToDescription")]
        public bool AllowReplyTo { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSFederationConfiguration),
            Name = "RequireReplyToWithinRealm", Description = "RequireReplyToWithinRealmDescription")]
        public bool RequireReplyToWithinRealm { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSFederationConfiguration),
            Name = "RequireSslForReplyTo", Description = "RequireSslForReplyToDescription")]
        public bool RequireSslForReplyTo { get; set; }
    }
}