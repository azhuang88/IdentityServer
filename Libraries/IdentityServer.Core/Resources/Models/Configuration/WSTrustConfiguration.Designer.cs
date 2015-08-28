﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IdentityServer.Core.Resources.Models.Configuration {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class WSTrustConfiguration {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal WSTrustConfiguration() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IdentityServer.Core.Resources.Models.Configuration.WSTrustConfiguration", typeof(WSTrustConfiguration).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable Client Certificates Authentication.
        /// </summary>
        public static string EnableClientCertificateAuthentication {
            get {
                return ResourceManager.GetString("EnableClientCertificateAuthentication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enables client certificate based authentication..
        /// </summary>
        public static string EnableClientCertificateAuthenticationDescription {
            get {
                return ResourceManager.GetString("EnableClientCertificateAuthenticationDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable Identity Delegation.
        /// </summary>
        public static string EnableDelegation {
            get {
                return ResourceManager.GetString("EnableDelegation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enables identity delegation..
        /// </summary>
        public static string EnableDelegationDescription {
            get {
                return ResourceManager.GetString("EnableDelegationDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable Federated Authentication.
        /// </summary>
        public static string EnableFederatedAuthentication {
            get {
                return ResourceManager.GetString("EnableFederatedAuthentication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enables federated authentication using a token from a trusted identity provider..
        /// </summary>
        public static string EnableFederatedAuthenticationDescription {
            get {
                return ResourceManager.GetString("EnableFederatedAuthenticationDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable Message Security Endpoints.
        /// </summary>
        public static string EnableMessageSecurity {
            get {
                return ResourceManager.GetString("EnableMessageSecurity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enables the message security endpoints..
        /// </summary>
        public static string EnableMessageSecurityDescription {
            get {
                return ResourceManager.GetString("EnableMessageSecurityDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable Mixed Mode Security Endpoints.
        /// </summary>
        public static string EnableMixedModeSecurity {
            get {
                return ResourceManager.GetString("EnableMixedModeSecurity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enables the mixed mode security endpoints..
        /// </summary>
        public static string EnableMixedModeSecurityDescription {
            get {
                return ResourceManager.GetString("EnableMixedModeSecurityDescription", resourceCulture);
            }
        }
    }
}
