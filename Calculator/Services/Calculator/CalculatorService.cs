using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator.Helpers;
using MathNet.Symbolics;

using Expr = MathNet.Symbolics.Expression;

namespace Calculator.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        public CalculatorService()
        {

        }

        public string Compute(Expression input)
        {
            try
            {
                // expand the math expression 
                Expr expression = Algebraic.Expand(input);

                // convert simplified math expression to string output 
                return Infix.Format(expression);
            }
            catch(Exception ex)
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
