using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class GenerateSequenceIntervalFacts
    {
        [Fact]
        public void stop_generating_sequence_if_result_is_less_than_zero()
        {
            int[] expected = { 7, 4, 1, -2 };

            Assert.Equal(expected, GenerateSequenceInterval(7, 3));
        }

        static IEnumerable<int> GenerateSequenceInterval(int start, int interval)
        {
            List<int> result = new List<int>();
            int i = start;
            while(i > 0)
            {
                result.Add(i);
                i -= interval;
            }
            result.Add(i);
            return result.ToArray();
        }
    }
}