using MathNet.Symbolics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Calculator
{
    public interface ICalculatorService
    {
        public string Compute(Expression input);
    }
}
