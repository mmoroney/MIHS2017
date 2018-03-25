using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MIHS2017
{
    [TestClass]
    public class HikingTest
    {
        private const int MaxWeight = 20;
        private const int MaxItems = 5;

        [TestMethod]
        public void TestHiking()
        {
            Assert.AreEqual(22, Hiking(new int[] { 5, 10, 3, 7, 4 }, new int[] { 6, 11, 2, 4, 5 }));
            Assert.AreEqual(28, Hiking(new int[] { 12, 5, 7, 4, 8 }, new int[] { 2, 12, 7, 2, 9 }));
        }

        public static int Hiking(int[] weights, int[] values)
        {
            int maxValue = 0;

            for(int i = 0; i < 32; i++)
            {
                int currentValue = 0;
                int currentWeight = 0;

                for (int j = 0; j < MaxItems; j++)
                {
                    if((i & (1 << j)) > 0)
                    {
                        currentWeight += weights[j];

                        if (currentWeight > MaxWeight)
                            break;

                        currentValue += values[j];
                    }
                }

                maxValue = Math.Max(maxValue, currentValue);
            }

            return maxValue;

        }
    }
}
