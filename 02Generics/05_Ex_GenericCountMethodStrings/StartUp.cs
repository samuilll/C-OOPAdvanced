using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {

        SpecificElementsCounter<double> counter = new SpecificElementsCounter<double>();

        List<double> data = new List<double>();

        int elementsNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < elementsNumber; i++)
        {
            double element = double.Parse(Console.ReadLine());

            data.Add(element);
        }

        double specificElement = double.Parse(Console.ReadLine());

        Console.WriteLine(counter.Count(data,specificElement));
    }
}

