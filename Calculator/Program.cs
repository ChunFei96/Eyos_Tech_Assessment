using Calculator.Calculator;
using Calculator.Controller;
using Calculator.Helpers;
using MathNet.Symbolics;
using Microsoft.Extensions.DependencyInjection;
using System;

using Expr = MathNet.Symbolics.Expression;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICalculatorService, CalculatorService>()
                .BuildServiceProvider();

            var _calculatorService = serviceProvider.GetService<ICalculatorService>();

            CalculatorController calculator = new CalculatorController(_calculatorService);

            // declare variables
            var x = Expr.Symbol("x");

            while (true)
            {
                Console.Write("Please enter math expression: ");

                string input = Console.ReadLine();

                Console.WriteLine(string.Format("Answer: {0}", calculator.Compute(input)));
            }
        }
    }
}
