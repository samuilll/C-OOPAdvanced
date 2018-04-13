using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO.Commands
{
    public abstract class Command:IExecutable
    {

        protected Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;                
        }

        private string input;

        public string Input
        {
            get { return input; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                input = value;
            }
        }

        private string[] data;

        public string[] Data
        {
            get { return data; }
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                data = value;
            }
        }

        protected void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }
        public abstract void Execute();

    }
}
