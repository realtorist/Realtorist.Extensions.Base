using Microsoft.Extensions.DependencyInjection;
using System;

namespace Realtorist.Extensions.Base
{
    /// <summary>
    /// Extension to configure services in DI
    /// </summary>
    public interface IConfigureServicesExtension : IExtension
    {
        /// <summary>
        /// Configures services in the DI
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="serviceProvider">Service provider which contains already registered services</param>
        void ConfigureServices(IServiceCollection services, IServiceProvider serviceProvider);
    }
}