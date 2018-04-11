using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        ListIterator iterator=null;

        while (true)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            var command = input[0];

            if (command=="END")
            {
                break;
            }

            try
            {
                iterator = ReadLine(iterator, input, command);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static ListIterator ReadLine(ListIterator iterator, List<string> input, string command)
    {
        switch (command)
        {
            case "Create":
                {
                    iterator = new ListIterator(input.Skip(1).ToList());
                    break;
                }
            case "HasNext":
                {
                    Console.WriteLine(iterator.HasNext());
                    break;
                }
            case "Print":
                {
                    iterator.Print();
                    break;
                }
            case "Move":
                {
                    Console.WriteLine(iterator.Move());
                    break;
                }
            case "PrintAll":
                {
                    iterator.PrintAll();
                    break;
                }
            default:
                break;
        }

        return iterator;
    }
}

//Create Stefcho Goshky
//HasNext
//Print
//Move
//Print
//END
