using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Calculator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;
using Calculator.Helpers;
using Moq;
using Calculator.Controller;
using Microsoft.Extensions.DependencyInjection;
using MathNet.Symbolics;
using System.Linq;

namespace Calculator.Calculator.Tests
{
    [TestClass()]
    public class CalculatorServiceTests
    {
        public ICalculatorService _calculatorService { get; set; }
        [TestInitialize]
        public void Initialize()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICalculatorService, CalculatorService>();

            var serviceProvider = services.BuildServiceProvider();

            _calculatorService = serviceProvider.GetService<ICalculatorService>();
        }

        [TestMethod()]
        public void ComputeTest_1()
        {
            string testinput = "1";
            string answer = "1";

            var result = _calculatorService.Compute(CalculatorHelpers.ConvertToExpr(testinput));

            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ComputeTest_2()
        {
            string testinput = "x";
            string answer = "x";

            var result = _calculatorService.Compute(CalculatorHelpers.ConvertToExpr(testinput));

            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ComputeTest_3()
        {
            string testinput = "(x+1)";
            string answer = "1+x";

            var result = _calculatorService.Compute(CalculatorHelpers.ConvertToExpr(testinput));
            result = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
            Assert.AreEqual(answer, result.Trim());
        }

        [TestMethod()]
        public void ComputeTest_4()
        {
            string testinput = "((1+2+1)*(1+1)*x)";
            string answer = "8*x";

            var result = _calculatorService.Compute(CalculatorHelpers.ConvertToExpr(testinput));
            result = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
            Assert.AreEqual(answer, result.Trim());
        }

        [TestMethod()]
        public void ComputeTest_5()
        {
            string testinput = "(1+(2*x)+1)";
            string answer = "2+2*x";

            var result = _calculatorService.Compute(CalculatorHelpers.ConvertToExpr(testinput));
            result = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
            Assert.AreEqual(answer, result.Trim());
        }

        [TestMethod()]
        public void ComputeTest_6()
        {
            string testinput = "((1+(2*x)+1)*(x+1))";
            string answer = "2+4*x+2*x^2";

            var result = _calculatorService.Compute(CalculatorHelpers.ConvertToExpr(testinput));
            result = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
            Assert.AreEqual(answer, result.Trim());
        }

    }
}