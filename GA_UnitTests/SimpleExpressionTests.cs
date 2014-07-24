using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GATest;

namespace GA_UnitTests
{
    [TestClass]
    public class SimpleExpressionTests
    {
        [TestMethod]
        public void TestInvalidExpression()
        {
            string input = "2 2 + 2";
            string expected = "2 + 2 ";

            var simpleExpr = new SimpleExpression(input);
            var actual = simpleExpr.Text;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidExpression2()
        {
            string input = "5 2 + 2";
            string expected = "5 + 2 ";

            var simpleExpr = new SimpleExpression(input);
            var actual = simpleExpr.Text;

            Assert.AreEqual(expected, actual);
        }
    }
}
