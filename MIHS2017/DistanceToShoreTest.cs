using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MIHS2017
{
    [TestClass]
    public class DistanceToShoreTest
    {
        [TestMethod]
        public void TestDistanceToShore()
        {
            Assert.AreEqual(10, DistanceToShore("A 15.2 C 18.3"));
            Assert.AreEqual(13, DistanceToShore("B 5 A 12"));
        }

        public static int DistanceToShore(string input)
        {
            string[] tokens = input.Split(' ');

            double d1 = Math.Pow(float.Parse(tokens[1]), 2);
            double d2 = Math.Pow(float.Parse(tokens[3]), 2);

            if (tokens[0] == "C" || tokens[2] == "C")
                d2 *= -1;

            return (int)Math.Sqrt(Math.Abs(d1 + d2));
        }
    }
}
