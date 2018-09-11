namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using _03BarracksFactory.Core.Commands;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandIterpreter)
        {
            this.commandInterpreter = commandIterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = this.commandInterpreter.InterpretCommand(data, commandName).Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
