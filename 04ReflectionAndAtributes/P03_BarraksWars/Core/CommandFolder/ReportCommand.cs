using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data) : base(data)
        {

        }
        public override string Execute()
        {
            return this.repository.Statistics;
        }
    }
}
