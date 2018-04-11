using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03DependencyInversion.Contracts
{
  public  interface IStrategy
    {
        int Calculate(int firstOperand,int secondOperand);
    }
}
