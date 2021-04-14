using Calculator.Calculator;
using Calculator.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Controller
{
    public class CalculatorController
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public string Compute (string input)
        {
            try
            {
                // convert user's input to mathNet symbolics expression
                MathNet.Symbolics.Expression expr = CalculatorHelpers.ConvertToExpr(input);

                // call calculator service to expand the expression
                string answer = _calculatorService.Compute(expr);

                // reverse the degree in descending order
                answer = CalculatorHelpers.ReverseDegreeOrder(CalculatorHelpers.ConvertToExpr(answer));

                return answer;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine(
                    "\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);
                Console.WriteLine(
                    "\nTargetSite ---\n{0}", ex.TargetSite);
                return null;
            }

        }
    }
}
