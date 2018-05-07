using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class MultiplesOfThree
    {
        [Fact]
        public void should_choose_multiple_of_3()
        {
            int[] collection = { 0, 1, 2, 3, 4, 5, 6, 9, 11};
            int[] expectedResult = {0, 3, 6, 9};

            Assert.Equal(expectedResult, ChooseMultipleOfThree(collection));
        }

        static IEnumerable<int> ChooseMultipleOfThree(IEnumerable<int> collection)
        {
            return collection.Where(item => item % 3 == 0).ToArray();
        }
    }
}