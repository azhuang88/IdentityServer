/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models.Configuration
{
    public class WSTrustConfiguration : ProtocolConfiguration
    {
        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSTrustConfiguration),
            Name = "EnableMessageSecurity", Description = "EnableMessageSecurityDescription")]
        public bool EnableMessageSecurity { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSTrustConfiguration),
            Name = "EnableMixedModeSecurity", Description = "EnableMixedModeSecurityDescription")]
        public bool EnableMixedModeSecurity { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSTrustConfiguration),
            Name = "EnableClientCertificateAuthentication",
            Description = "EnableClientCertificateAuthenticationDescription")]
        public bool EnableClientCertificateAuthentication { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSTrustConfiguration),
            Name = "EnableFederatedAuthentication", Description = "EnableFederatedAuthenticationDescription")]
        public bool EnableFederatedAuthentication { get; set; }

        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.WSTrustConfiguration), Name = "EnableDelegation",
            Description = "EnableDelegationDescription")]
        public bool EnableDelegation { get; set; }
    }
}