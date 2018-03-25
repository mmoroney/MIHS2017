using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MIHS2017
{
    [TestClass]
    public class CompoundInterestTest
    {
        [TestMethod]
        public void TestCompoundInterest()
        {
            Assert.AreEqual("$1190", CompoundInterest("1000 4 0.035 5"));
            Assert.AreEqual("$4096", CompoundInterest("2500 2 0.05 10"));
        }

        public static string CompoundInterest(string input)
        {
            string[] tokens = input.Split(' ');
            int P = int.Parse(tokens[0]);
            int n = int.Parse(tokens[1]);
            float r = float.Parse(tokens[2]);
            int t = int.Parse(tokens[3]);
            int A = (int)(P * Math.Pow(1.0 + r / n, n * t));

            return string.Format("${0}", A);
        }
    }
}
