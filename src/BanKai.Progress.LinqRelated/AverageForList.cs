using System;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class AverageForList
    {
        [Fact]
        public void should_calculate_average()
        {
            const string listString = "1->3->5->98->67->456";
            const int expect = 105;

            Assert.Equal(expect, CalculateAverage(listString));
        }

        static int CalculateAverage(string listString)
        {
            string[] stringList = listString.Split(new string[] {"->"}, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            for (int i = 0; i < stringList.Length; i++)
            {
                sum += int.Parse(stringList[i]);
            }

            int average = sum / stringList.Length;
            return average;
        }
    }
}