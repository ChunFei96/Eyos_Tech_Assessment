using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Symbolics;

namespace Calculator.Helpers
{
    public static class CalculatorHelpers
    {
        public static MathNet.Symbolics.Expression ConvertToExpr(string input)
        {
            try
            {
                return Infix.ParseOrThrow(input);
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

        public static string ReverseDegreeOrder(Expression expression)
        {
            try
            {
                return string.Join("+", Algebraic.Summands(expression).Reverse().Select(Infix.Format));
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

        public static bool isOperator(char _char)
        {
            if (_char.Equals('+') || _char.Equals('*'))
                return true;
            return false;
        }

        public static bool isBracket(char _char)
        {
            if (_char.Equals('(') || _char.Equals(')'))
                return true;
            return false;
        }

        public static int PriorityRank(char _char)
        {
            int priority = 0;

            if (_char.Equals('*'))
                return 2;
            else if (_char.Equals('+'))
                return 1;

            return priority;
        }
    }
}
