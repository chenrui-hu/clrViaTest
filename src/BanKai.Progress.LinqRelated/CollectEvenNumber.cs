using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class CollectEvenNumber
    {
        [Fact]
        public void should_collect_all_even_number()
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] expected = { 2, 4 };

            IEnumerable<int> result = CollectAllEvenNumbers(source);

            Assert.Equal(expected, result);
        }

        static IEnumerable<int> CollectAllEvenNumbers(int[] source)
        {
            // TODO: write your implementation here.
            return source.Where(item => item % 2 == 0);
        }
    }
}