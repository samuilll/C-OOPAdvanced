using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandString = "Command";

        private IServiceProvider service;
    public CommandInterpreter(IServiceProvider service)
    {
        this.service = service;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        string commandName = args[0];

        Type type = Assembly.GetExecutingAssembly().GetTypes().First(t=>t.Name==commandName+CommandString);

        var ctorParams = type.GetConstructors().First().GetParameters();

        var objectsParams = new object[ctorParams.Length];

        for (int i = 0; i < ctorParams.Length-1; i++)
        {
            objectsParams[i] = this.service.GetService(ctorParams[i].ParameterType);
        }
        var p = args.Skip(1).ToList();
        objectsParams[objectsParams.Length - 1] = args.Skip(1).ToList();

        ICommand command = (ICommand)Activator.CreateInstance(type,objectsParams);

        //if (typeof(ICommand).IsAssignableFrom(type))
        //{

        //}

        return command.Execute();
    }
}

