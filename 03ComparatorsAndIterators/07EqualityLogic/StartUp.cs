using System;
using System.Collections.Generic;

class StartUp
    {
        static void Main(string[] args)
        {
        int lineNumber = int.Parse(Console.ReadLine());

        SortedSet<Person> firstSet = new SortedSet<Person>();
        HashSet<Person> secondSet = new HashSet<Person>();


        for (int i = 0; i < lineNumber; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];

            int age = int.Parse(input[1]);

            Person person = new Person(name, age);

            firstSet.Add(person);
            secondSet.Add(person);

        }
        Console.WriteLine(firstSet.Count);
        Console.WriteLine(secondSet.Count);

    }
}

