using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thankifi.Common.Filters.Abstractions;

namespace Thankifi.Common.Filters
{
    /// <summary>
    /// Binary filter.
    /// </summary>
    public class BinaryFilter : IFilter
    {
        /// <inheritdoc />
        public string Identifier => "binary";

        /// <inheritdoc />
        public Task<string> Apply(string str, CancellationToken cancellationToken = default)
        {
            var encoding = new UTF8Encoding();
            byte[] buf = encoding.GetBytes(str);

            var binaryStringBuilder = new StringBuilder();
            foreach (var b in buf)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2));
            }

            return Task.FromResult(binaryStringBuilder.ToString());
        }
    }
}