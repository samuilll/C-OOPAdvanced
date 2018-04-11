using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


  public  class CommandInterpreter
    {

    public CommandInterpreter(WeaponRepository repository, WeaponFactory weaponFactory, GemFactory gemFactory)
    {
        this.repository = repository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    private WeaponRepository repository;
    private WeaponFactory weaponFactory;
    private GemFactory gemFactory;

    public IExecutable InterpretCommand(string commandName)
    {
        Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower() + "command");

        if (commandType==null)
        {
            throw new ArgumentException("There is no such a command!");
        }

       IExecutable command =  (IExecutable)Activator.CreateInstance(commandType, new object[] {});

        CheckForInjections(command);

        return command;

    }

    private void CheckForInjections(IExecutable command)
    {
        FieldInfo[] fieldsToInject = command
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.GetCustomAttributes().Any(a => a.GetType() == typeof(InjectionAttribute)))
            .ToArray();

        FieldInfo[] interpreterFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToArray();

        foreach (var field in fieldsToInject)
        {
            field.SetValue(command, interpreterFields.First(f => f.FieldType == field.FieldType).GetValue(this));
        }
    }
}

