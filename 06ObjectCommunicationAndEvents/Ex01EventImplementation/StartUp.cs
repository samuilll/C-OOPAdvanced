using System;

namespace Ex01EventImplementation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            INameChangeable dispatcher = new Dispatcher("Pesho");
            INameChangeHandler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;
            while ((input = Console.ReadLine()) !="End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
