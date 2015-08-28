/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql
{
    public class ClientCertificates
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Thumbprint { get; set; }

        [Required]
        public string Description { get; set; }
    }
}