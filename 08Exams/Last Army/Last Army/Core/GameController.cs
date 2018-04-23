using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


    public class GameController
    {

    private const string EndString = "End";
    private const string CommandSufix = "Command";

    private IServiceProvider service;

        public GameController(IServiceProvider serviceProvider)
        {
        this.service = serviceProvider;
        }
    public void ReadCommand(string input)
    {
        var args = input.Split();

        string commandName = args[0];

        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName + CommandSufix);

        if (type==null)
        {
            commandName = EndString;
            type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == commandName + CommandSufix);
        }
        if (type == null)
        {
            throw new ArgumentException("No such a class");
        }
        if (!typeof(ICommand).IsAssignableFrom(type))
        {
            throw new ArgumentException("No such a command");
        }

        var ctorParams = type.GetConstructors().First().GetParameters();

        var objectsParams = new object[ctorParams.Length];

        objectsParams[0] = args.Skip(1).ToList();

        for (int i = 1; i < ctorParams.Length; i++)
        {
            objectsParams[i] = this.service.GetService(ctorParams[i].ParameterType);
        }
       

        ICommand command = (ICommand)Activator.CreateInstance(type, objectsParams);

         command.Execute();
    }
   

    }




