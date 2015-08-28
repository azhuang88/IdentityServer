/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

namespace IdentityServer.Protocols.OAuth2
{
    public class OAuth2ConsentViewModel
    {
        public string ResourceName { get; set; }
        public string ResourceUri { get; set; }
        public string ClientName { get; set; }
        public bool RefreshTokenEnabled { get; set; }
    }
}