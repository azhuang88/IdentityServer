/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql
{
    public class Delegation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Realm { get; set; }

        public string Description { get; set; }
    }
}