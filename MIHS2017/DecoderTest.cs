using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class DecoderTest
    {
        [TestMethod]
        public void TestDecoder()
        {
            Assert.AreEqual("hello person.  this is the message i want to share with you.",
                Decoder("8 5 12 12 15 27 16 5 18 19 15 14 28 27 27 20 8 9 19 27 9 19 27 20 " + 
                "8 5 27 13 5 19 19 1 7 5 27 9 27 23 1 14 20 27 20 15 27 19 8 1 18 5 27 23 9 " + 
                "20 8 27 25 15 21 28"));
        }

        public static string Decoder(string input)
        {
            string[] tokens = input.Split(' ');

            StringBuilder sb = new StringBuilder();

            foreach(string token in tokens)
            {
                if (token == "27")
                    sb.Append(' ');
                else if (token == "28")
                    sb.Append('.');
                else
                    sb.Append((char)((int)'a' + int.Parse(token) - 1));
            }

            return sb.ToString();
        }
    }
}
