using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Symbolics;
using System.Linq;

namespace Calculator.Helpers.Tests
{
    [TestClass()]
    public class CalculatorHelpersTests
    {
        [TestMethod()]
        public void ConvertToExprTest()
        {
            string testinput = "(1+x)";
            string answer = "1+x";

            var expr = CalculatorHelpers.ConvertToExpr(testinput);
            var result = string.Concat(Infix.Format(expr).Where(c => !char.IsWhiteSpace(c)));
            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ReverseDegreeOrderTest()
        {
            string testinput = "(2+4*x+2*x^2)";
            string answer = "2*x^2+4*x+2";

            var result = CalculatorHelpers.ReverseDegreeOrder(CalculatorHelpers.ConvertToExpr(testinput));

            Assert.AreEqual(answer, result);
        }
    }
}