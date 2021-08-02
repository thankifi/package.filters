using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thankifi.Common.Filters.Abstractions;

namespace Thankifi.Common.Filters
{
    /// <summary>
    /// Mock filter.
    /// </summary>
    public class MockFilter : IFilter
    {
        /// <inheritdoc />
        public string Identifier => "mock";

        /// <inheritdoc />
        public Task<string> Apply(string str, CancellationToken cancellationToken = default)
        {
            var lastIsUpper = true;
            var stringBuilder = new StringBuilder(str.Length);

            foreach (var character in str)
            {
                if (char.IsLetter(character))
                {
                    stringBuilder.Append(lastIsUpper ? char.ToLower(character) : char.ToUpper(character));
                    lastIsUpper = !lastIsUpper;
                }
                else
                {
                    stringBuilder.Append(character);
                }
            }

            return Task.FromResult(stringBuilder.ToString());
        }
    }
}