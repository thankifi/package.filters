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
        /// Applies a filter to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="filter">The identifier of the <see cref="IFilter"/> to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <exception cref="InvalidFilterException">When the requested filter does not exists.</exception>
        /// <returns>The transformed string.</returns>
        Task<string> Apply(string filter, string str, CancellationToken cancellationToken = default);

        /// <summary>
        /// Applies a filter to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="filter">The identifier of the <see cref="IFilter"/> to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>The transformed string or default if something went wrong..</returns>
        Task<string?> ApplyOrDefault(string filter, string str, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Applies one or more filters to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="filters">The list with the identifiers of the <see cref="IFilter"/>s to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <exception cref="InvalidFilterException">When the requested filter does not exists.</exception>
        /// <returns>The transformed string.</returns>
        Task<string> Apply(IEnumerable<string> filters, string str, CancellationToken cancellationToken = default);

        /// <summary>
        /// Applies one or more filter to a string given a filter identifier and an input string.
        /// </summary>
        /// <param name="filters">The list with the identifiers of the <see cref="IFilter"/>s to apply.</param>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>The transformed string or default if something went wrong..</returns>
        Task<string?> ApplyOrDefault(IEnumerable<string> filters, string str, CancellationToken cancellationToken = default);
    }
}