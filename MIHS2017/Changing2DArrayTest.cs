using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class Changing2DArrayTest
    {
        [TestMethod]
        public void TestChanging2DArray()
        {
            Assert.AreEqual(
@"5 71 2
8 81 3
2 3 12
3249 3 21
",
Changing2DArray(new string[] { "3 4", "5 71 2", "8 9 15", "2 20 1645", "57 40 105"}));
        }

        public static string Changing2DArray(string[] args)
        {
            string[] tokens = args[0].Split(' ');
            int cols = int.Parse(tokens[0]);
            int rows = int.Parse(tokens[1]);

            StringBuilder sb = new StringBuilder();

            for(int i = 1; i <= rows; i++)
            {
                string[] numbers = args[i].Split(' ');
                for(int j = 0; j < cols; j++)
                {
                    int n = int.Parse(numbers[j]);

                    if (n % 3 == 0)
                    {
                        if (n % 5 == 0)
                            n /= 5;
                        else
                            n *= n;
                    }
                    else if (n % 5 == 0)
                        n = (int)Math.Round(Math.Pow(n, 1.0 / i));

                    if (j != 0)
                        sb.Append(' ');

                    sb.Append(n);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
