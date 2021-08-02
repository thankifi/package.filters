using System.Threading;
using System.Threading.Tasks;

namespace Thankifi.Common.Filters.Abstractions
{
    /// <summary>
    /// Filter interface.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Filter identifier.
        /// </summary>
        string Identifier { get; }
        
        /// <summary>
        /// Applies the filter to the incoming string.
        /// </summary>
        /// <param name="str">The incoming string.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>The transformed string.</returns>
        Task<string> Apply(string str, CancellationToken cancellationToken = default);
    }
}