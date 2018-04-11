using System;
using System.Collections.Generic;

class StartUp
    {
        static void Main(string[] args)
        {

        int lineNumber = int.Parse(Console.ReadLine());

        SortedSet<Person> firstSet = new SortedSet<Person>(new FirstComparator());
        SortedSet<Person> secondSet = new SortedSet<Person>(new SecondComparator());


        for (int i = 0; i < lineNumber; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];

            int age = int.Parse(input[1]);

            Person person = new Person(name, age);

            firstSet.Add(person);
            secondSet.Add(person);
            
        }

        foreach (var person in firstSet)
        {
            Console.WriteLine(person);
        }
        foreach (var person in secondSet)
        {
            Console.WriteLine(person);
        }
    }
    }

