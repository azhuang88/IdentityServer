using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IdentityServer.Protocols.WSFederation
{
    public class AtozViewModel : ContentResult
    {
        [Display(ResourceType = typeof(Resources.WSFederation.AtozViewModel), Name = "SiteTitle")]
        public string SiteTitle { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = @"Email not in correct format")]
        [Display(ResourceType = typeof(Resources.WSFederation.AtozViewModel), Name = "Email")]
        public string Email { get; set; }

        bool? isSigninRequest;
        public bool IsSigninRequest
        {
            get
            {
                if (isSigninRequest == null)
                {
                    isSigninRequest = !String.IsNullOrWhiteSpace(ReturnUrl);
                }
                return isSigninRequest.Value;
            }
            set
            {
                isSigninRequest = value;
            }
        }

        [Display(ResourceType = typeof(Resources.WSFederation.AtozViewModel), Name = "Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool ShowClientCertificateLink { get; set; }
        public string Domain { get; set; }

        [Display(ResourceType = typeof(Resources.WSFederation.AtozViewModel), Name = "Remember")]
        public bool RememberMe { get; set; }
    }
}
