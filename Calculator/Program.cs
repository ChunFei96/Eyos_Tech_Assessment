using Calculator.Calculator;
using Calculator.Controller;
using Calculator.Helpers;
using MathNet.Symbolics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
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

            string testinput = "((1+2+1)*(1+1)*x)";
            Console.WriteLine(InfixToPostFix(testinput));
            //// declare variables
            //var x = Expr.Symbol("x");

            //while (true)
            //{

            //    Console.Write("Please enter math expression: ");

            //    string input = Console.ReadLine();

            //    Console.WriteLine(string.Format("Answer: {0}", calculator.Compute(input)));

            //}
        }

        static string InfixToPostFix(string input)
        {
            Stack<char> operatorStack = new Stack<char>();
            string Postfix = string.Empty;
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char _char = input[i];
                    if (CalculatorHelpers.isOperator(_char) || CalculatorHelpers.isBracket(_char))
                    {
                        // Assume the input is valid where bracket inserted properly
                        // first char should be (
                        if (_char != ')')
                        {
                            if (CalculatorHelpers.isBracket(_char))
                            {
                                operatorStack.Push(_char);
                            }
                            else if (CalculatorHelpers.isOperator(_char))
                            {
                                if (CalculatorHelpers.PriorityRank(_char) > CalculatorHelpers.PriorityRank(operatorStack.Peek()))
                                {
                                    operatorStack.Push(_char);
                                }
                                else
                                {
                                    for (int j = 0; j < operatorStack.Count; j++)
                                    {
                                        if (operatorStack.Peek() != '(')
                                        {

                                            char popChar = operatorStack.Peek();
                                            operatorStack.Pop();
                                            Postfix += popChar;
                                        }
                                    }
                                    operatorStack.Push(_char);
                                }
                            }

                        }

                        else
                        {
                            for (int j = 0; j < operatorStack.Count; j++)
                            {
                                if (operatorStack.Peek() != '(')
                                {

                                    char popChar = operatorStack.Pop();
                                    Postfix += popChar;
                                }
                            }

                        }

                    }
                    else
                    {
                        Postfix += _char;
                    }
                }

            }
            catch (Exception e)
            {
                return null;
            }

            return Postfix;

        }

        public void Addition()
        {
            VA vA = new VA();
            VA vA2 = new VA();

            if (vA.variable == vA2.variable)
            {
                var answer = vA.number + vA2.number;
            }


        }



    }

    public class VA
    {
        public int number { get; set; }
        public char variable { get; set; }

    }
}
