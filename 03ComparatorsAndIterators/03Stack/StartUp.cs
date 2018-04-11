using System;
using System.Linq;

namespace _03Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                var input = Console.ReadLine().Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries);

                var command = input[0];

                if (command=="END")
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "Push":
                            {
                                stack.Push(input.Skip(1));
                                break;
                            }
                        case "Pop":
                            {
                                stack.Pop();
                                break;
                            }
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }    
        }
    }
}
