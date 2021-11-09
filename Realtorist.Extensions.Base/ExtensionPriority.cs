using System;

namespace Realtorist.Extensions.Base
{
    /// <summary>
    /// Contains default load priorities for extensions
    /// </summary>
    public enum ExtensionPriority
    {
        /// <summary>
        /// Register AutoMapper profile
        /// </summary>
        RegisterAutoMapperProfile = 1,

        /// <summary>
        /// Register implementations in DI
        /// </summary>
        RegisterImplementations = 10,

        /// <summary>
        /// Register default implementations in DI
        /// </summary>
        RegisterDefaultImplementations = 50,

        /// <summary>
        /// Configures main application
        /// </summary>
        MainApplication = 100,

        /// <summary>
        /// Configures theme
        /// </summary>
        Theme = 1000
    }
}
