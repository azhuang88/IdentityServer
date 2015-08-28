/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class ClientCertificate
    {
        [Required]
        [Display(ResourceType = typeof (Core.Resources.Models.ClientCertificate), Name = "Description",
            Description = "DescriptionDescription")]
        public string Description { get; set; }

        [Required]
        [Display(ResourceType = typeof (Core.Resources.Models.ClientCertificate), Name = "UserName",
            Description = "UserNameDescription")]
        public string UserName { get; set; }

        [UIHint("Thumbprint")]
        [Required]
        [Display(ResourceType = typeof (Core.Resources.Models.ClientCertificate), Name = "Thumbprint",
            Description = "ThumbprintDescription")]
        public string Thumbprint { get; set; }
    }
}