using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private IProviderController providerController;

    private IHarvesterController harvesterController;

    private IReader reader;

    private IWriter writer;

    private StringBuilder builder;

    private const string ShutDown = "Shutdown";

    private ICommandInterpreter interpreter;

    public Engine(IReader reader, IWriter writer, StringBuilder builder, ICommandInterpreter interpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.builder = builder;
        this.interpreter = interpreter;
    }

    public void Run()
    {
        List<string> args = new List<string>() {" "};

        while (args[0]!=ShutDown)
        {
             args = reader.ReadLine().Split().ToList();

            builder.AppendLine(this.interpreter.ProcessCommand(args));
        }

        writer.WriteLine(this.builder.ToString());
    }
}

