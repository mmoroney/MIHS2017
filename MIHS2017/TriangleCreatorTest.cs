using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class TriangleCreatorTest
    {
        [TestMethod]
        public void TestTriangleCreator()
        {
            Assert.AreEqual(
@"  /\  
 /  \ 
/____\
", TriangleCreator(3));

            Assert.AreEqual(
@"    /\    
   /  \   
  /    \  
 /      \ 
/________\
", TriangleCreator(5));
        }

        public static string TriangleCreator(int N)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < N; i++)
            {
                char[] array = new char[2 * N];
                for(int j = 0; j < array.Length; j++)
                {
                    char c = ' ';
                    if (j == N - i - 1)
                        c = '/';
                    else if (j == N + i)
                        c = '\\';
                    else if(i == N - 1)
                        c = '_';

                    array[j] = c;
                }

                sb.AppendLine(new string(array));
            }

            return sb.ToString();
        }
    }
}
