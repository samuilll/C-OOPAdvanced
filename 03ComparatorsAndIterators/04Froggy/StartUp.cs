using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
    {
        static void Main()
        {

        Lake lake = new Lake(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        var output = new List<object>();

        foreach (var item in lake)
        {
            output.Add(item);
        }
        Console.WriteLine(string.Join(", ",output));
        }
    }

