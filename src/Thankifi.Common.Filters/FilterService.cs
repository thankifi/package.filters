using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Thankifi.Common.Filters.Abstractions;
using Thankifi.Common.Filters.Exceptions;

namespace Thankifi.Common.Filters
{
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
        public async Task<string> Apply(string filter, string str, CancellationToken cancellationToken = default)
        {
            var selectedFilter = _filters.FirstOrDefault(f => f.Identifier == filter);

            if (selectedFilter is null)
            {
                throw new InvalidFilterException();
            }

            return await selectedFilter.Apply(str, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<string?> ApplyOrDefault(string filter, string str, CancellationToken cancellationToken = default)
        {
            try
            {
                return await Apply(filter, str, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}