using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class GroupingNumbers
    {
        [Fact]
        public void should_grouping_count()
        {
            int[] collection = { 1, 1, 1, 1, 2, 3, 1, 3, 4, 2, 3, 1, 3, 4, 2 };
            int[] result = {6, 3, 4, 2};

            Assert.Equal(result, GroupingNumbersAndSort(collection));
        }

        static IEnumerable<int> GroupingNumbersAndSort(IEnumerable<int> collection)
        {
            IEnumerable<int> keys = new int[]{};
            List<int> result = new List<int>();
            keys = collection.GroupBy(item => item).Select(item => item.Key);
            foreach (var key in keys)
            {
                result.Add(collection.Count(item => item == key));
            }
            return result.ToArray();

        }
    }
}