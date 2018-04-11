using System;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {



        int elementsNumber = int.Parse(Console.ReadLine());

        SwapableCollection<int> data = new SwapableCollection<int>();

        for (int i = 0; i < elementsNumber; i++)
        {
            int element =int.Parse(Console.ReadLine());

            data.AddItem(element);
        }

        int[] indexers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int firstIndex = indexers[0];

        int secondIndex = indexers[1];

        data.Swap(firstIndex, secondIndex);

        foreach (var item in data.Items)
        {
            Console.WriteLine($"{item.GetType()}: {item}");
        }
    }
}



