using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class FlattenIntersectionFacts
    {
        [Fact]
        public void should_get_intersection_from_multi_dimensional_collections()
        {
            char[] collectionA = { 'a', 'e', 'h', 't', 'f', 'c', 'g', 'b', 'd' };
            char[][] collectionB =
            {
                new[] {'a', 'd'}, new[] {'e', 'f'}
            };
            char[] expected = {'a', 'd', 'e', 'f'};

            Assert.Equal(expected, GetIntersection(collectionA, collectionB));
        }

        IEnumerable<char> GetIntersection(
            IEnumerable<char> collectionA,
            IEnumerable<char[]> collectionB)
        {
            IEnumerable<char> result = new char[] { };
            foreach (char[] oneDArray in collectionB)
            {
                result = result.Concat(collectionA.Intersect(oneDArray));
            }

            return result.ToArray();
        }
    }
}