/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System;

namespace IdentityServer.Models
{
    public class CodeToken
    {
        public string Code { get; set; }
        public int ClientId { get; set; }
        public string UserName { get; set; }
        public string Scope { get; set; }
        public CodeTokenType Type { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}