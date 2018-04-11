using P03_DependencyInversion;
using System;

namespace Ex03DependencyInversion
{
    class StartUp
    {

        static void Main()
        {

            PrimitiveCalculator calculator = new PrimitiveCalculator();

            while (true)
            {
                string[] args = Console.ReadLine().Split();

                if (args[0]=="End")
                {
                    break;
                }
                else if (args[0]=="mode")
                {
                    calculator.ChangeStrategy(args[1][0]);
                }
                else
                {
                    int firstNum = int.Parse(args[0]);
                    int secondNum = int.Parse(args[1]);
                    Console.WriteLine(calculator.PerformCalculation(firstNum, secondNum));
                }

            }
        }
    }
}
