using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class Engine
    {

    private CommandInterpreter interpreter;

    public Engine()
    {
        this.interpreter = new CommandInterpreter();
    }

    public void Run()
    {
        while (this.interpreter.IsInProcess)
        {
            try
            {
                this.interpreter.ReadCommand(Console.ReadLine().Split().ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    }

