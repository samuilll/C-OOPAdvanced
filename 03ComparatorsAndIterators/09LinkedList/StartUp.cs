using System;

    class StartUp
    {
        static void Main(string[] args)
        {
        LinkedList<int> list = new LinkedList<int>();

        int linesNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < linesNumber; i++)
        {
            var input = Console.ReadLine().Split();

            var operation = input[0];

            var number = int.Parse(input[1]);

            switch (operation)
            {
                case "Add":
                    {
                        list.Add(number);
                        break;
                    }
                case "Remove":
                    {
                        list.Remove(number);
                        break;
                    }
                default:
                    break;
            }
        }

        Console.WriteLine(list.Count);

        foreach (var item in list)
        {
            Console.Write(item+" ");
        }

        Console.WriteLine();
        }
    }

