using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Thankifi.Common.Filters.Exceptions;

namespace Thankifi.Common.Filters.Abstractions
{
    /// <summary>
    /// Filter Service.
    /// </summary>
    public interface IFilterService
    {
        /// <summary>
        /// Get a list of the identifiers for all available filters.
        /// </summary>
        /// <returns>A list of identifiers.</returns>
        IEnumerable<string> GetAvailableFilterIdentifiers();

        /// <summary>
        /// Get a filter instance given a identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the <see cref="IFilter"/>.</param>
        /// <exception cref="InvalidFilterException">When the requested filter does not exists.</exception>
        /// <returns>A instance of the <see cref="IFilter"/></returns>
        IFilter GetFilter(string identifier);

        /// <summary>
        /// Get a filter instance given a identifier or null if it does not exist.
        /// </summary>
        /// <param name="identifier">The identifier of the <see cref="IFilter"/>.</param>
        /// <returns>A instance of the <see cref="IFilter"/></returns>
        IFilter? GetFilterOrDefault(string identifier);

        /// <summary>
        /// Try to get a filter given a identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the <see cref="IFilter"/>.</param>
        /// <param name="filter">A reference to store the <see cref="IFilter"/>.</param>
        /// <returns>A instance of the <see cref="IFilter"/></returns>
        bool TryGetFilter(string identifier, out IFilter filter);
        
        /// <summary>
        /// Applies a filter to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="identifier">The identifier of the <see cref="IFilter"/> to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <exception cref="InvalidFilterException">When the requested filter does not exists.</exception>
        /// <returns>The transformed string.</returns>
        Task<string> Apply(string identifier, string str, CancellationToken cancellationToken = default);

        /// <summary>
        /// Applies a filter to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="identifier">The identifier of the <see cref="IFilter"/> to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>The transformed string or default if something went wrong.</returns>
        Task<string?> ApplyOrDefault(string identifier, string str, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Applies one or more filters to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="identifiers">The list with the identifiers of the <see cref="IFilter"/>s to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <exception cref="InvalidFilterException">When the requested filter does not exists.</exception>
        /// <returns>The transformed string.</returns>
        Task<string> Apply(IEnumerable<string> identifiers, string str, CancellationToken cancellationToken = default);

        /// <summary>
        /// Applies one or more filter to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="identifiers">The list with the identifiers of the <see cref="IFilter"/>s to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>The transformed string or default if something went wrong.</returns>
        Task<string?> ApplyOrDefault(IEnumerable<string> identifiers, string str, CancellationToken cancellationToken = default);
    }
}