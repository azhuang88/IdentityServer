/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models.Configuration
{
    public class DiagnosticsConfiguration
    {
        [Display(ResourceType = typeof (Core.Resources.Models.Configuration.DiagnosticsConfiguration),
            Name = "EnableFederationMessageTracing", Description = "EnableFederationMessageTracingDescription")]
        public bool EnableFederationMessageTracing { get; set; }
    }
}