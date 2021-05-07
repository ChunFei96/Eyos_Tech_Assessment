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

            //string testinput = "((1+2+1)*(1+1)*x)";
            //Console.WriteLine(InfixToPostFix(testinput));

            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Pair Programming");
            Console.WriteLine("Addition & Multiplication of math expression (Assume only 1 variable)");
            Cal cal = new Cal();
            cal.number = 7;
            cal.variable = "x";

            Cal cal1 = new Cal();
            cal1.number = 4;
            cal1.variable = "x";

            Cal cal2 = new Cal();
            cal2.number = 7;
            cal2.variable = "x^3";

            Cal cal3 = new Cal();
            cal3.number = 4;
            cal3.variable = "x^2";

            Console.WriteLine(String.Format("{0}{1} + {2}{3} = {4}", cal.number.ToString(), cal.variable, cal1.number.ToString(), cal1.variable, cal.Addition(cal, cal1)));
            Console.WriteLine(String.Format("{0}{1} * {2}{3} = {4}", cal2.number.ToString(), cal2.variable, cal3.number.ToString(), cal3.variable, cal.Multiple(cal2, cal3)));

            Console.WriteLine("---------------------------------------------------------------------------------------\n");

            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Technical Assessment");
            // declare variables
            var x = Expr.Symbol("x");

            while (true)
            {

                Console.Write("Please enter math expression: ");

                string input = Console.ReadLine();

                Console.WriteLine(string.Format("Answer: {0}", calculator.Compute(input)));

            }


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
    }

    public class Cal
    {
        public int number { get; set; }
        public string variable { get; set; }

        public string Addition(Cal A1, Cal A2)
        {
            var answer = string.Empty;
            if (A1.variable.Equals(A2.variable))
            {
                answer += (A1.number + A2.number).ToString();
                answer += A1.variable;
            }

            return answer;
        }

        public string Multiple(Cal A1, Cal A2)
        {
            var answerNumber = 0;
            var answerVariable = string.Empty;

            answerNumber = A1.number * A2.number;

            int A1power = 1;
            int A2power = 1;
            string _variable = string.Empty;
            int totalPower = 0;
            if (A1.variable.Contains("^"))
            {
                _variable = A1.variable.Split('^')[0];
                A1power = Convert.ToInt32(A1.variable.Split('^')[1]);

            }

            if (A2.variable.Contains("^"))
            {
                _variable = A2.variable.Split('^')[0];
                A2power = Convert.ToInt32(A2.variable.Split('^')[1]);
            }

            totalPower = A1power + A2power;
            answerVariable = _variable + "^" + totalPower.ToString();



            return answerNumber + "*" + answerVariable;
        }
    }
}
