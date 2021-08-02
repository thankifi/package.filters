using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thankifi.Common.Filters.Abstractions;

namespace Thankifi.Common.Filters
{
    /// <summary>
    /// Leet filter.
    /// </summary>
    public class LeetFilter : IFilter
    {
        /// <inheritdoc />
        public string Identifier => "leet";

        /// <inheritdoc />
        public Task<string> Apply(string str, CancellationToken cancellationToken = default)
        {
            var stringBuilder = new StringBuilder(str.Length);
            
            foreach (var character in str)
            {
                stringBuilder.Append(LeetDict.TryGetValue(character, out var newChar) ? newChar : character);
            }

            return Task.FromResult(stringBuilder.ToString());
        }

        private static ReadOnlyDictionary<char, char> LeetDict => new(new Dictionary<char, char>
        {
            ['a'] = '4',
            ['b'] = '8',
            ['e'] = '3',
            ['g'] = '9',
            ['i'] = '1',
            ['l'] = '1',
            ['o'] = '0',
            ['q'] = 'k',
            ['s'] = '5',
            ['t'] = '7',
            ['z'] = '2',
            ['A'] = '4',
            ['B'] = '8',
            ['E'] = '3',
            ['G'] = '6',
            ['I'] = '1',
            ['O'] = '0',
            ['Q'] = 'O',
            ['S'] = '5',
            ['T'] = '7',
            ['Z'] = '2',
            ['0'] = 'O',
            ['1'] = 'l',
            ['2'] = 'z',
            ['3'] = 'E',
            ['4'] = 'A',
            ['5'] = 'S',
            ['6'] = 'G',
            ['7'] = 'T',
            ['8'] = 'B',
            ['9'] = 'g',
        });
    }
}