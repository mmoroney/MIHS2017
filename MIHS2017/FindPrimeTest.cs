using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class FindPrimeTest
    {
        [TestMethod]
        public void TestFindPrime()
        {
            Assert.AreEqual("2 3 25 49 121 169 17 19", FindPrime("8 5 15"));
            Assert.AreEqual("4 9 25", FindPrime("3 1 5"));
            Assert.AreEqual("2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 79 83 89 97 101", FindPrime("26 80 82"));
        }

        public static string FindPrime(string input)
        {
            string[] tokens = input.Split(' ');
            int N = int.Parse(tokens[0]);
            int K1 = int.Parse(tokens[1]);
            int K2 = int.Parse(tokens[2]);

            StringBuilder sb = null;

            int p = 2;
            while (N > 0)
            {
                if(isPrime(p))
                {
                    if (sb == null)
                        sb = new StringBuilder();
                    else
                        sb.Append(' ');

                    sb.Append((p >= K1 && p <= K2) ? p * p : p);
                    N--;
                }
                p++;
            }            
            return sb.ToString();
        }

        private static bool isPrime(int p)
        {
            if (p < 1)
                return false;

            if (p == 2)
                return true;

            for(int i = 2; i * i <= p; i++)
            {
                if (p % i == 0)
                    return false;
            }

            return true;
        }
    }
}
