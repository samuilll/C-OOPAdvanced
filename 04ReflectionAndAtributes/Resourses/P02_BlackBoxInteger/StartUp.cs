using System;
using System.Collections;
using System.Linq;
using System.Reflection;

class StartUp
{
    static void Main()
    {
        BlackBoxIntegerTests test = new BlackBoxIntegerTests(typeof(BlackBoxInteger));

        while (true)
        {
            string[] args = Console.ReadLine().Split('_');

            if (args[0]=="END")
            {
                break;
            }

            string method = args[0];

            int value = int.Parse(args[1]);

            Console.WriteLine(test.InvokeMethod(method, value));

        }
    }
}



