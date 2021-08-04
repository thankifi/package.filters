using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Thankifi.Common.Filters.Abstractions;
using Thankifi.Common.Filters.Exceptions;

namespace Thankifi.Common.Filters
{
    /// <inheritdoc />
    public class FilterService : IFilterService
    {
        /// <summary>
        /// Available filters.
        /// </summary>
        protected readonly IEnumerable<IFilter> Filters;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="filters"></param>
        public FilterService(IEnumerable<IFilter> filters)
        {
            Filters = filters;
        }

        /// <inheritdoc />
        public IEnumerable<string> GetAvailableFilterIdentifiers()
        {
            return Filters.Select(filter => filter.Identifier);
        }

        /// <inheritdoc />
        public IFilter GetFilter(string identifier)
        {
            var filter = Filters.FirstOrDefault(f => f.Identifier == identifier);

            if (filter is null)
            {
                throw new InvalidFilterException();
            }

            return filter;
        }

        /// <inheritdoc />
        public IFilter? GetFilterOrDefault(string identifier)
        {
            return Filters.FirstOrDefault(f => f.Identifier == identifier);
        }

        /// <inheritdoc />
        public bool TryGetFilter(string identifier, out IFilter filter)
        {
            filter = Filters.FirstOrDefault(f => f.Identifier == identifier);

            return filter is not null;
        }

        /// <inheritdoc />
        public async Task<string> Apply(string identifier, string str, CancellationToken cancellationToken = default)
        {
            var filter = Filters.FirstOrDefault(f => f.Identifier == identifier);

            if (filter is null)
            {
                throw new InvalidFilterException();
            }

            return await filter.Apply(str, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<string?> ApplyOrDefault(string identifier, string str, CancellationToken cancellationToken = default)
        {
            try
            {
                return await Apply(identifier, str, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <inheritdoc />
        public async Task<string> Apply(IEnumerable<string> identifiers, string str, CancellationToken cancellationToken = default)
        {
            foreach (var filter in identifiers)
            {
                str = await Apply(filter, str, cancellationToken).ConfigureAwait(false);
            }

            return str;
        }

        /// <inheritdoc />
        public async Task<string?> ApplyOrDefault(IEnumerable<string> identifiers, string str, CancellationToken cancellationToken = default)
        {
            foreach (var filter in identifiers)
            {
                var filtered = await ApplyOrDefault(filter, str, cancellationToken).ConfigureAwait(false);

                if (filtered is not null)
                {
                    str = filtered;
                }
            }

            return str;
        }
    }
}