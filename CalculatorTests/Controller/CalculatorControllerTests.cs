using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Calculator;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Controller.Tests
{
    [TestClass()]
    public class CalculatorControllerTests
    {
        public ICalculatorService _calculatorService { get; set; }
        public CalculatorController calculator { get; set; }
        [TestInitialize]
        public void Initialize()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICalculatorService, CalculatorService>();

            var serviceProvider = services.BuildServiceProvider();

            _calculatorService = serviceProvider.GetService<ICalculatorService>();

            calculator = new CalculatorController(_calculatorService);
        }

        [TestMethod()]
        public void ComputeTest_1()
        {
            string testinput = "1";
            string answer = "1";

            var result = calculator.Compute(testinput);

            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ComputeTest_2()
        {
            string testinput = "x";
            string answer = "x";

            var result = calculator.Compute(testinput);

            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ComputeTest_3()
        {
            string testinput = "(x+1)";
            string answer = "x+1";

            var result = calculator.Compute(testinput);

            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ComputeTest_4()
        {
            string testinput = "((1+2+1)*(1+1)*x)";
            string answer = "8*x";

            var result = calculator.Compute(testinput);

            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ComputeTest_5()
        {
            string testinput = "(1+(2*x)+1)";
            string answer = "2*x+2";

            var result = calculator.Compute(testinput);

            Assert.AreEqual(answer, result);
        }

        [TestMethod()]
        public void ComputeTest_6()
        {
            string testinput = "((1+(2*x)+1)*(x+1))";
            string answer = "2*x^2+4*x+2";

            var result = calculator.Compute(testinput);

            Assert.AreEqual(answer, result);
        }
    }
}