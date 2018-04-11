using Ex03DependencyInversion.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03DependencyInversion.Strategies
{
    public class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
