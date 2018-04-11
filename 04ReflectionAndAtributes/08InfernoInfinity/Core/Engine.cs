using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{

    private CommandInterpreter commandInterpreter;

    public Engine(CommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            string[] data = Console.ReadLine().Split(';').ToArray();

            string commandName = data[0];

            if (commandName=="END")
            {
                break;
            }
            if (data.Length>1)
            {
                data = data.Skip(1).ToArray();
            }

            try
            {
                this.commandInterpreter.InterpretCommand(commandName).Execute(data);
            }
            catch (ArgumentException ex)
            {
              //  Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
             //   Console.WriteLine(ex.Message);
            }
        }
    }
}

