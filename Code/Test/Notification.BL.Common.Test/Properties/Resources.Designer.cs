﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notification.BL.Common.Test.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Notification.BL.Common.Test.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;notificationTypes&quot;: [
        ///    &quot;0&quot;
        ///  ],
        ///  &quot;applicationName&quot;: &quot;Expense&quot;,
        ///  &quot;notificationTag&quot;: &quot;F29C1D04-4546-4813-BBAD-2B16E9938BEE&quot;,
        ///  &quot;deeplinkUrl&quot;: &quot;http://expense&quot;,
        ///  &quot;sendOnUtcDate&quot;: &quot;&quot;,
        ///  &quot;from&quot;: &quot;alias@domain.com&quot;,
        ///  &quot;to&quot;: &quot;alias@domain.com&quot;,
        ///  &quot;cc&quot;: &quot;alias@domain.com&quot;,
        ///  &quot;bcc&quot;: &quot;alias@domain.com&quot;,
        ///  &quot;subject&quot;: &quot;Your Expense has been successfully submitted!&quot;,
        ///  &quot;body&quot;: &quot;&quot;,
        ///  &quot;attachments&quot;: [
        ///    {
        ///      &quot;fileName&quot;: &quot;testing.txt&quot;,
        ///      &quot;fileBase64&quot;: &quot;VGhpcyBpcyBhIHRlc3QgZmlsZSBmb3IgYX [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NotificationItem {
            get {
                return ResourceManager.GetString("NotificationItem", resourceCulture);
            }
        }
    }
}