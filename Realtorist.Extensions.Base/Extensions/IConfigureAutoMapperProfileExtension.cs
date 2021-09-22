using AutoMapper;
using System.Collections.Generic;

namespace Realtorist.Extensions.Base
{
    /// <summary>
    /// Extension to configure application in DI
    /// </summary>
    public interface IConfigureAutoMapperProfileExtension : IExtension
    {
        /// <summary>
        /// Provides AutoMapper profiles to be regisetered
        /// </summary>
        /// <returns>AutoMapper profiles to be registered</returns>
        IEnumerable<Profile> GetAutoMapperProfiles();
    }
}