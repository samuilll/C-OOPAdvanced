using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using BashSoft.Judge;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO
{
    public class CommandInterpreter : IInterpreter
    {

        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                IExecutable currentCommand = this.ParseCommand(input, data, commandName);

                currentCommand.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }

        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {

            object[] parametersForCommandConstructor = new object[]
            {
                input, data
            };

            Type interpreterType = typeof(CommandInterpreter);

            Type commandType = Assembly.GetExecutingAssembly()
                 .GetTypes()
                 .First(t => t.GetCustomAttributes(typeof(AliasAttribute))
                 .Any(atr => atr.Equals(command)));

            IExecutable currentCommand = (IExecutable)Activator.CreateInstance(commandType, parametersForCommandConstructor);

            InjectFieldsInCurrentCommand(currentCommand,interpreterType);

            return currentCommand;
        }

        private void InjectFieldsInCurrentCommand(IExecutable currentCommand,Type interpreterType)
        {
            FieldInfo[] fieldsToInject = currentCommand.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttributes(typeof(InjectAttribute)).Any())
                .ToArray();

            FieldInfo[] interpreterFields = interpreterType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            for (int i = 0; i < fieldsToInject.Length; i++)
            {

                FieldInfo fieldToInject = fieldsToInject[i];

                FieldInfo interpreterField = interpreterType.
                    GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(f => f.FieldType.Name == fieldToInject.FieldType.Name);

                var sdf = interpreterField.FieldType.Name; 

                fieldToInject.SetValue(currentCommand, interpreterField.GetValue(this));
            }


        }
    }
}
