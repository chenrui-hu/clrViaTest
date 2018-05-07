using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class MapToEven
    {
        [Fact]
        public void should_map_to_even()
        {
            int[] collection = { 1, 2, 3, 4, 5 };
            int[] expected = { 2, 4, 6, 8, 10 };
            
            Assert.Equal(expected, MapEven(collection));
        }

        static IEnumerable<int> MapEven(IEnumerable<int> collection)
        {
            return collection.Select(item => item * 2).ToArray();
        }
    }
}