using System;
using System.Collections.Generic;
using System.Reflection;

namespace Realtorist.Extensions.Base.Manager
{
    /// <summary>
    /// Provides methods to work with the extensions in the system
    /// </summary>
    public interface IExtensionManager
    {
        /// <summary>
        /// Gets type which implements specified interface
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation type</returns>
        Type GetImplementation<T>();

        /// <summary>
        /// Gets type which implements specified interface
        /// </summary>
        /// <param name="predicate">Predicate to filter assembly of the implementation type</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation type</returns>
        Type GetImplementation<T>(Func<Assembly, bool> predicate);

        /// <summary>
        /// Gets types which implement specified interface
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation types</returns>
        IEnumerable<Type> GetImplementations<T>();

        /// <summary>
        /// Gets types which implement specified interface
        /// </summary>
        /// <param name="args">Additional arguments for the implementation constructor</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation types</returns>
        IEnumerable<Type> GetImplementations<T>(Func<Assembly, bool> predicate);

        /// <summary>
        /// Gets implementation of the specified interface
        /// </summary>
        /// <param name="predicate">Predicate to filter assembly of the implementation type</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation object</returns>
        T GetInstance<T>();

        /// <summary>
        /// Gets implementation of the specified interface
        /// </summary>
        /// <param name="predicate">Predicate to filter assembly of the implementation type</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation object</returns>
        T GetInstance<T>(params object[] args);

        /// <summary>
        /// Gets implementation of the specified interface
        /// </summary>
        /// <param name="predicate">Predicate to filter assembly of the implementation type</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation object</returns>
        T GetInstance<T>(Func<Assembly, bool> predicate);

        /// <summary>
        /// Gets implementation of the specified interface
        /// </summary>
        /// <param name="predicate">Predicate to filter assembly of the implementation type</param>
        /// <param name="args">Additional arguments for the implementation constructor</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>Implementation object</returns>
        T GetInstance<T>(Func<Assembly, bool> predicate, params object[] args);

        /// <summary>
        /// Gets all implementation sof the specified interface
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>All implementations objects</returns>
        IEnumerable<T> GetInstances<T>();

        /// <summary>
        /// Gets all implementation of the specified interface
        /// </summary>
        /// <param name="args">Additional arguments for the implementation constructors</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>All implementations objects</returns>
        IEnumerable<T> GetInstances<T>(params object[] args);

        /// <summary>
        /// Gets all implementation of the specified interface
        /// </summary>
        /// <param name="predicate">Predicate to filter assembly of the implementation type</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>All implementations objects</returns>
        IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate);

        /// <summary>
        /// Gets all implementations of the specified interface
        /// </summary>
        /// <param name="predicate">Predicate to filter assembly of the implementation type</param>
        /// <param name="args">Additional arguments for the implementation constructors</param>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns>All implementation objects</returns>
        IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, params object[] args);
    }
}