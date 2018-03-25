using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MIHS2017
{
    [TestClass]
    public class TexasHoldemTest
    {
        [TestMethod]
        public void TestTexasHoldem()
        {
            Assert.AreEqual("10 10", TexasHoldem("10 10 9 9 A J K"));
            Assert.AreEqual("Q Q Q", TexasHoldem("Q 2 J Q J Q A"));
        }

        public static string TexasHoldem(string input)
        {
            string cards = "A23456789TJQK";
            string[] tokens = input.Split(' ');
            int[] counts = new int[13];

            foreach(string token in tokens)
            {
                int index = token == "10" ? 9 : cards.IndexOf(token[0]);
                counts[index]++;
            }

            int highest = 0;
            for (int i = counts.Length - 1; i > 0; i--)
            {
                if (counts[i] < 2)
                    continue;

                if(counts[i] == 3)
                {
                    highest = i;
                    break;
                }

                if(highest == 0)
                    highest = i;
            }

            string card = (highest == 9) ? "10" : cards[highest].ToString();

            if (counts[highest] == 3)
                return string.Format("{0} {0} {0}", card);

            return string.Format("{0} {0}", card);
        }
    }
}
