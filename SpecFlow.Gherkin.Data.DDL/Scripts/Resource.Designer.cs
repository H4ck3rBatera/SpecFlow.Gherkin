//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpecFlow.Gherkin.Data.DDL.Scripts {
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
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SpecFlow.Gherkin.Data.DDL.Scripts.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = &apos;CustomerBase&apos;)
        ///BEGIN
        ///    CREATE DATABASE CustomerBase
        ///END.
        /// </summary>
        internal static string CreateDatabase {
            get {
                return ResourceManager.GetString("CreateDatabase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF NOT EXISTS(SELECT * FROM sys.tables WHERE NAME = &apos;Customer&apos; AND type = &apos;U&apos;)
        ///BEGIN
        ///    CREATE TABLE Customer
        ///      (
        ///         ID       INT IDENTITY(1,1) NOT NULL,
        ///         Name     NVARCHAR(50) NOT NULL,
        ///         LastName NVARCHAR(50) NOT NULL,
        ///         Document NVARCHAR(14) NOT NULL UNIQUE,
        ///         CONSTRAINT pk_customer PRIMARY KEY CLUSTERED (id ASC)
        ///      )
        ///END.
        /// </summary>
        internal static string CreateTableCustomer {
            get {
                return ResourceManager.GetString("CreateTableCustomer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS(SELECT * FROM sys.databases WHERE name = &apos;CustomerBase&apos;)
        ///BEGIN
        ///	USE master;
        ///	ALTER DATABASE CustomerBase SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
        ///	DROP DATABASE CustomerBase;
        ///END.
        /// </summary>
        internal static string DropDatabase {
            get {
                return ResourceManager.GetString("DropDatabase", resourceCulture);
            }
        }
    }
}
