using System;

namespace _01DataBase
{
    public class StartUp
    {

        public static void Main()
        {
           var database = new ExtendedDatabase(new Person(122, "Vanio"), new Person(3, "Gonko"));

            Console.WriteLine();
        }
    }
}
