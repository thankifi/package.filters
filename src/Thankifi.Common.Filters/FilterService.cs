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
        private readonly IEnumerable<IFilter> _filters;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="filters"></param>
        public FilterService(IEnumerable<IFilter> filters)
        {
            _filters = filters;
        }

        /// <inheritdoc />
        public IEnumerable<string> GetAvailableFilterIdentifiers()
        {
            return _filters.Select(filter => filter.Identifier);
        }

        /// <inheritdoc />
        public IFilter GetFilter(string identifier)
        {
            var filter = _filters.FirstOrDefault(f => f.Identifier == identifier);

            if (filter is null)
            {
                throw new InvalidFilterException();
            }

            return filter;
        }

        /// <inheritdoc />
        public IFilter? GetFilterOrDefault(string identifier)
        {
            return _filters.FirstOrDefault(f => f.Identifier == identifier);
        }

        /// <inheritdoc />
        public async Task<string> Apply(string identifier, string str, CancellationToken cancellationToken = default)
        {
            var selectedFilter = _filters.FirstOrDefault(f => f.Identifier == identifier);

            if (selectedFilter is null)
            {
                throw new InvalidFilterException();
            }

            return await selectedFilter.Apply(str, cancellationToken).ConfigureAwait(false);
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
                str = await Apply(filter, str, cancellationToken);
            }

            return str;
        }

        /// <inheritdoc />
        public async Task<string?> ApplyOrDefault(IEnumerable<string> identifiers, string str, CancellationToken cancellationToken = default)
        {
            foreach (var filter in identifiers)
            {
                var filtered = await ApplyOrDefault(filter, str, cancellationToken);

                if (filtered is not null)
                {
                    str = filtered;
                }
            }

            return str;
        }
    }
}