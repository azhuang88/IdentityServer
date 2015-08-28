/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models.Configuration
{
    public class ProtocolConfiguration
    {
        [Display(Order = 1, ResourceType = typeof (Core.Resources.Models.Configuration.ProtocolConfiguration),
            Name = "Enabled", Description = "EnabledDescription")]
        public bool Enabled { get; set; }
    }
}