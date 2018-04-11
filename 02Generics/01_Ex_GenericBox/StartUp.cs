using System;


    class StartUp
    {
        static void Main()
        {

        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            int number = int.Parse(Console.ReadLine());

            GenericBox<int> box = new GenericBox<int>(number);

            Console.WriteLine(box);
        }
        }
    }

