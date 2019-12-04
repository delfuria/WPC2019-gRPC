using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class CalculatorService : ICalculator
    {
        public double Sum(double op1, double op2)
        {
            double result = op1+op2;
            return result;
        }
    }
}
