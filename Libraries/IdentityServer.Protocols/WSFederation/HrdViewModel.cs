/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Services;
using System.Linq;
using IdentityServer.Models;

namespace IdentityServer.Protocols.WSFederation
{
    public class HrdViewModel
    {
        public HrdViewModel(SignInRequestMessage message, IEnumerable<IdentityProvider> idps)
        {
            OriginalSigninUrl = message.WriteQueryString();
            Providers = idps.Select(x => new HRDIdentityProvider {DisplayName = x.DisplayName, ID = x.Name}).ToArray();
        }

        public IEnumerable<HRDIdentityProvider> Providers { get; set; }
        public string OriginalSigninUrl { get; set; }

        [Display(ResourceType = typeof (Resources.WSFederation.HrdViewModel), Name = "RememberHRDSelection")]
        public bool RememberHRDSelection { get; set; }
    }

    public class HRDIdentityProvider
    {
        public string ID { get; set; }
        public string DisplayName { get; set; }
    }
}