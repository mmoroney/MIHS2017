using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class InspirationalMessageTest
    {
        [TestMethod]
        public void TestInspirationalMessage()
        {
            string expected = @"/----------\
\*!Amazing!*/
\*!Awesome!*/
\*!Fantastic!*/
\----------/";

            string actual = InspirationalMessage(new string[] { "Amazing", "Awesome", "Fantastic" });
            Assert.AreEqual(expected, actual);
        }

        public static string InspirationalMessage(String[] messages)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("/----------\\");

            foreach (String message in messages)
                builder.AppendLine(string.Format("\\*!{0}!*/", message));

            builder.Append("\\----------/");
            return builder.ToString();
        }
    }
}
