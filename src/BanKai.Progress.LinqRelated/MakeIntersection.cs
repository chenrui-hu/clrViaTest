using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class MakeIntersection
    {
        [Fact]
        public void should_get_intersection()
        {
            int[] collectionA = { 10, 27, 28, 19, 5 };
            int[] collectionB = { 5, 78, 28, 19, 23 };
            int[] intersection = { 19, 28, 5 };

            Assert.Equal(intersection, GetIntersectionAndSort(collectionA, collectionB));
        }

        static IEnumerable<int> GetIntersectionAndSort(IEnumerable<int> c1, IEnumerable<int> c2)
        {
            return c2.Intersect(c1).Reverse().ToArray();

        }
    }
}