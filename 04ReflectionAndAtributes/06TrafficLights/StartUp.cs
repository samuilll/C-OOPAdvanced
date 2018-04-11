using System;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {

       // Console.WriteLine(Enum.GetValues(typeof(Color)).ToString());

        var trafficLights = Console.ReadLine()
            .Split()
            .Select(x => new TrafficLight(x))
.ToList();
        int times = int.Parse(Console.ReadLine());

        for (int i = 0; i < times; i++)
        {
            trafficLights.ForEach(tl => tl.ChangeLight());

            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}

