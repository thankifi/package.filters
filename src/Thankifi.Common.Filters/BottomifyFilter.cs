using System.Threading;
using System.Threading.Tasks;
using Bottom;
using Thankifi.Common.Filters.Abstractions;

namespace Thankifi.Common.Filters
{
    /// <summary>
    /// Bottomify filter.
    /// </summary>
    public class BottomifyFilter : IFilter
    {
        /// <inheritdoc />
        public string Identifier => "bottomify";

        /// <inheritdoc />
        public Task<string> Apply(string str, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Bottomify.EncodeString(str));
        }
    }
}