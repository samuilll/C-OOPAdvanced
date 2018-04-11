using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
     //  Console.WriteLine(new HarvestingFieldsTest().Run());

        //Cars car = Cars.None;

        //while (true)
        //{
        //  var  input = Console.ReadLine();

        //    if (input=="end")
        //    {
        //        break;
        //    }

        //    // car = (Cars)Enum.Parse(typeof(Cars), input);

        //    Enum.TryParse<Cars>(input, out Cars value);

        //    if (value!=null)
        //    {
        //        car |= value;
        //    }

        //    bool check = car.HasFlag(value);

        //    car ^= value;

        //}

        var list = new List<string>(4);

        for (int i = 0; i < 10; i++)
        {
            list.Add("sw");
        }


        Console.WriteLine(string.Join(", ",list));

    }
    [Flags]
     enum Cars
    {
        None = 0,
        Mercedes = 1,
        Ferrari = 2,
        Lada = 4,
        Pigeot = 8,
        All = 15
    }
}

