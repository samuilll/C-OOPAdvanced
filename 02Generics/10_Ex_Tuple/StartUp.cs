using System;


    class StartUp
    {
        static void Main(string[] args)
        {

        var nameAdress = Console.ReadLine().Split();
        string firstName = nameAdress[0];
        string secondName = nameAdress[1];
        string address = nameAdress[2];

        var nameLiters = Console.ReadLine().Split();
        string name = nameLiters[0];
        int liters = int.Parse(nameLiters[1]);

        var intDouble = Console.ReadLine().Split();
        int integer = int.Parse(intDouble[0]);
        double doubleger = double.Parse(intDouble[1]);

        Tuple<string, string> stringTuple = new Tuple<string, string>(firstName+" "+secondName,address);
        Tuple<string, int> stringIntTuple = new Tuple<string, int>(name,liters);
        Tuple<int, double> intDoubleTuple = new Tuple<int, double>(integer,doubleger);

        Console.WriteLine(stringTuple);
        Console.WriteLine(stringIntTuple);
        Console.WriteLine(intDoubleTuple);

    }
}

