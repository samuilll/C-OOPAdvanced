using System;


    class StartUp
    {
        static void Main(string[] args)
        {
        var nameAdress = Console.ReadLine().Split();
        string firstName = nameAdress[0];
        string secondName = nameAdress[1];
        string address = nameAdress[2];
        string town = nameAdress[3];

        var nameLiters = Console.ReadLine().Split();
        string name = nameLiters[0];
        int liters = int.Parse(nameLiters[1]);
        bool drunk = nameLiters[2] == "drunk";

        var stringDoubleString = Console.ReadLine().Split();
        string bankAccount = stringDoubleString[0];
        double doubleger = double.Parse(stringDoubleString[1]);
        string bank = stringDoubleString[2];

        Tuple<string, string,string> stringTuple = new Tuple<string, string,string>(firstName + " " + secondName, address,town);
        Tuple<string, int,bool> stringIntTuple = new Tuple<string, int,bool>(name, liters,drunk);
        Tuple<string, double,string> intDoubleTuple = new Tuple<string, double,string>(bankAccount, doubleger,bank);

        Console.WriteLine(stringTuple);
        Console.WriteLine(stringIntTuple);
        Console.WriteLine(intDoubleTuple);
    }
    }

