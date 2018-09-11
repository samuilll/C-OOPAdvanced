using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        public string[] Data { get; protected set; }

        public Command(string[] data)
        {
            this.Data = data;
        }
        public abstract string Execute();
        
        
    }
}
