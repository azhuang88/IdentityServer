﻿using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Repositories.Sql.Configuration
{
    public class SimpleHttpConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }
    }
}