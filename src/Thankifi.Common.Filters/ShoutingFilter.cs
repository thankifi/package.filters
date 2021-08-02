using System.Threading;
using System.Threading.Tasks;
using Thankifi.Common.Filters.Abstractions;

namespace Thankifi.Common.Filters
{
    /// <summary>
    /// Shouting filter.
    /// </summary>
    public class ShoutingFilter : IFilter
    {
        /// <inheritdoc />
        public string Identifier => "shouting";

        /// <inheritdoc />
        public Task<string> Apply(string str, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(str.ToUpper());
        }
    }
}