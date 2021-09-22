using Microsoft.AspNetCore.Builder;
using System;

namespace Realtorist.Extensions.Base
{
    /// <summary>
    /// Extension to configure application in DI
    /// </summary>
    public interface IConfigureApplicationExtension : IExtension
    {
        /// <summary>
        /// Configures services in the DI
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="serviceProvider">Service provider which contains already registered services</param>
        void ConfigureApplication(IApplicationBuilder app, IServiceProvider serviceProvider);
    }
}