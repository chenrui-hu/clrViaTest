﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class FlatenMultiDimensionalArray
    {
        [Fact]
        public void should_flaten_multi_dimensional_array()
        {
            int[][] jaggedArray = new[]
            {
                new[] {1, 2, 3},
                new[] {5, 2, 4, 1},
                new[] {2, 1}
            };
            int[] expectedResult = {1, 2, 3, 4, 5};

            Assert.Equal(expectedResult, FlattenMultiDimensionalArrayAndSort(jaggedArray));
        }

        static IEnumerable<int> FlattenMultiDimensionalArrayAndSort(IEnumerable<int[]> jaggedArray)
        {
            IEnumerable<int> result = new int[] { };
            foreach (int[] arr in jaggedArray)
            {
                result = result.Union(arr);
            }

            return result.OrderBy(item => item).ToArray();
        }
    }
}