﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatingApp.Resources.Helpers {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Helpers {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Helpers() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DatingApp.Resources.Helpers.Helpers", typeof(Helpers).Assembly);
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
        ///   Looks up a localized string similar to Details.
        /// </summary>
        public static string DisplayTypeDetails {
            get {
                return ResourceManager.GetString("DisplayTypeDetails", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Gallery.
        /// </summary>
        public static string DisplayTypeGallery {
            get {
                return ResourceManager.GetString("DisplayTypeGallery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All Users.
        /// </summary>
        public static string FilterAll {
            get {
                return ResourceManager.GetString("FilterAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Photo.
        /// </summary>
        public static string FilterNoPhoto {
            get {
                return ResourceManager.GetString("FilterNoPhoto", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Photo Only.
        /// </summary>
        public static string FilterPhotoOnly {
            get {
                return ResourceManager.GetString("FilterPhotoOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last Visit.
        /// </summary>
        public static string SortTypeLastVisit {
            get {
                return ResourceManager.GetString("SortTypeLastVisit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Newest Users.
        /// </summary>
        public static string SortTypeNewestUsers {
            get {
                return ResourceManager.GetString("SortTypeNewestUsers", resourceCulture);
            }
        }
    }
}
