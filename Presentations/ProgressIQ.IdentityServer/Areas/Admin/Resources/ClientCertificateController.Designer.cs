﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.Resources {
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
    public class ClientCertificateController {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ClientCertificateController() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProgressIQ.IdentityServer.Web.Areas.Admin.Resources.ClientCertificateController", typeof(ClientCertificateController).Assembly);
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
        ///   Looks up a localized string similar to Certificate Added.
        /// </summary>
        public static string CertificateAdded {
            get {
                return ResourceManager.GetString("CertificateAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Certificate Removed.
        /// </summary>
        public static string CertificateRemoved {
            get {
                return ResourceManager.GetString("CertificateRemoved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error adding client certificate..
        /// </summary>
        public static string ErrorAddingClientCertificate {
            get {
                return ResourceManager.GetString("ErrorAddingClientCertificate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error deleting client certificates..
        /// </summary>
        public static string ErrorDeletingClientCertificates {
            get {
                return ResourceManager.GetString("ErrorDeletingClientCertificates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error removing client certificate..
        /// </summary>
        public static string ErrorRemovingClientCertificate {
            get {
                return ResourceManager.GetString("ErrorRemovingClientCertificate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User Certificates Deleted.
        /// </summary>
        public static string UserCertificatesDeleted {
            get {
                return ResourceManager.GetString("UserCertificatesDeleted", resourceCulture);
            }
        }
    }
}
