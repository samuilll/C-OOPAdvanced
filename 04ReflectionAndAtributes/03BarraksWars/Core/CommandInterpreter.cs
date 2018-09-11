using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {

        private IRepository repository;
        private IUnitFactory unitFactory;
        public CommandInterpreter(IRepository repository,IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data,string commandName)
        {
            commandName = GetOperationName(commandName);

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            if (type == null)
            {
                throw new ArgumentException("You are in bug trouble!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(type))
            {
              throw  new ArgumentException("No!!!");
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(type, new object[] {data});

            this.InjectDependencies(command);

            return command;
        }

        private void InjectDependencies(IExecutable command)
        {
            Type injectionType = typeof(InjectAttribute);

            FieldInfo[] interpreterFields = this.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] fieldsToInject = command.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttributes().Any(a => a.GetType() == typeof(InjectAttribute)))
                .ToArray();

            foreach (FieldInfo field in fieldsToInject)
            {
                field.SetValue(command, interpreterFields.First(f => f.FieldType == field.FieldType).GetValue(this));
            }
           // FieldInfo[] 
        }

        private string GetOperationName(string commandName)
        {
            var builder = new StringBuilder();

            char firstLetter = char.ToUpper(commandName[0]);
            builder.Append(firstLetter);
            for (int i = 1; i < commandName.Length; i++)
            {
                builder.Append(commandName[i]);
            }

            return builder.ToString();
        }
    }
}
