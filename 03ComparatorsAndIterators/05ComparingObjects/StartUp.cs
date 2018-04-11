using System;
using System.Collections.Generic;

class StartUp
    {
        static void Main(string[] args)
        {

        List<Person> data = new List<Person>();

        while (true)
        {
            var input = Console.ReadLine().Split();

            if (input[0]=="END")
            {
                break;
            }

            string name = input[0];
            int age = int.Parse(input[1]);
            string town = input[2];

            Person currentPerson = new Person(name,age,town);

            data.Add(currentPerson);
        }

        int serchaedIndex = int.Parse(Console.ReadLine())-1;
        Person searchedPerson = data[serchaedIndex];
        int equals = 0;

        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].CompareTo(searchedPerson)==0)
            {
                equals++;
            }
        }
        if (equals>1)
        {
            int nonEquals = data.Count - equals;
            Console.Write(equals+" ");
            Console.Write(nonEquals+ " ");
            Console.WriteLine(equals+nonEquals);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
    }

