using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Realtorist.Extensions.Base.Helpers
{
    /// <summary>
    /// Contains useful helpers for the <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionHelpers
    {
        /// <summary>
        /// Adds new service implementation if service type wasn't already registered
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceType">Service type</param>
        /// <param name="implementationType">Implementation type</param>
        /// <param name="serviceLifetime">Service lifetime</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddServiceIfNotRegisteredYet(this IServiceCollection serviceCollection, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
        {
            if (!serviceCollection.Any(x => x.ServiceType == serviceType))
            {
                serviceCollection.Add(new ServiceDescriptor (serviceType, implementationType, serviceLifetime));
            }

            return serviceCollection;
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with scoped lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceType">Service type</param>
        /// <param name="implementationType">Implementation type</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddScopedServiceIfNotRegisteredYet(this IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            return serviceCollection.AddServiceIfNotRegisteredYet(serviceType, implementationType, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with transient lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceType">Service type</param>
        /// <param name="implementationType">Implementation type</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddTransientServiceIfNotRegisteredYet(this IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            return serviceCollection.AddServiceIfNotRegisteredYet(serviceType, implementationType, ServiceLifetime.Transient);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with singleton lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceType">Service type</param>
        /// <param name="implementationType">Implementation type</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddSingletonServiceIfNotRegisteredYet(this IServiceCollection serviceCollection, Type serviceType, Type implementationType)
        {
            return serviceCollection.AddServiceIfNotRegisteredYet(serviceType, implementationType, ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceLifetime">Service lifetime</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <typeparam name="TImplementation">Implementation type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddServiceIfNotRegisteredYet<TService, TImplementation>(this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime)
            where TService : class
            where TImplementation : class, TService
        {
            return serviceCollection.AddServiceIfNotRegisteredYet(typeof(TService), typeof(TImplementation), serviceLifetime);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with scoped lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <typeparam name="TImplementation">Implementation type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddScopedServiceIfNotRegisteredYet<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
        {
            return serviceCollection.AddServiceIfNotRegisteredYet<TService, TImplementation>(ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with transient lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <typeparam name="TImplementation">Implementation type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddTransientServiceIfNotRegisteredYet<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
        {
            return serviceCollection.AddServiceIfNotRegisteredYet<TService, TImplementation>(ServiceLifetime.Transient);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with singleton lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <typeparam name="TImplementation">Implementation type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddSingletonServiceIfNotRegisteredYet<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
        {
            return serviceCollection.AddServiceIfNotRegisteredYet<TService, TImplementation>(ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceType">Service type</param>
        /// <param name="factory">Implementation factory</param>
        /// <param name="serviceLifetime">Service lifetime</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddServiceIfNotRegisteredYet(this IServiceCollection serviceCollection, Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime serviceLifetime)
        {
            if (!serviceCollection.Any(x => x.ServiceType == serviceType))
            {
                serviceCollection.Add(new ServiceDescriptor(serviceType, factory, serviceLifetime));
            }

            return serviceCollection;
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="factory">Implementation factory</param>
        /// <param name="serviceLifetime">Service lifetime</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection, Func<IServiceProvider, TService> factory, ServiceLifetime serviceLifetime)
        {
            return AddServiceIfNotRegisteredYet(serviceCollection, typeof(TService), (serviceProvider) => factory(serviceProvider), serviceLifetime);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with scoped lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="factory">Implementation factory</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddScopedServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection, Func<IServiceProvider, TService> factory)
        {
            return AddServiceIfNotRegisteredYet(serviceCollection, typeof(TService), (serviceProvider) => factory(serviceProvider), ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with transient lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="factory">Implementation factory</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddTransientServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection, Func<IServiceProvider, TService> factory)
        {
            return AddServiceIfNotRegisteredYet(serviceCollection, typeof(TService), (serviceProvider) => factory(serviceProvider), ServiceLifetime.Transient);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with singleton lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="factory">Implementation factory</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddSingletonServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection, Func<IServiceProvider, TService> factory)
        {
            return AddServiceIfNotRegisteredYet(serviceCollection, typeof(TService), (serviceProvider) => factory(serviceProvider), ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceType">Service type</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime)
            where TService: class
        {
            if (!serviceCollection.Any(x => x.ServiceType == typeof(TService)))
            {
                serviceCollection.Add(new ServiceDescriptor(typeof(TService), typeof(TService), serviceLifetime));
            }

            return serviceCollection;
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with scoped lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddScopedServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection)
            where TService : class
        {
            return AddServiceIfNotRegisteredYet<TService>(serviceCollection, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with transient lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddTransientServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection)
            where TService : class
        {
            return AddServiceIfNotRegisteredYet<TService>(serviceCollection, ServiceLifetime.Transient);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with signelton lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddSingletonServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection)
            where TService : class
        {
            return AddServiceIfNotRegisteredYet<TService>(serviceCollection, ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds new service implementation if service type wasn't already registered with singleton lifetime
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="implementation">Object implementing <typeparamref name="TService"/></param>
        /// <typeparam name="TService">Service type</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddSingletonServiceIfNotRegisteredYet<TService>(this IServiceCollection serviceCollection, TService implementation)
        {
            if (!serviceCollection.Any(x => x.ServiceType == typeof(TService)))
            {
                serviceCollection.Add(new ServiceDescriptor(typeof(TService), implementation));
            }

            return serviceCollection;
        }
    }
}