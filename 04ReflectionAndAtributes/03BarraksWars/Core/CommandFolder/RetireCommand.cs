using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
  public  class RetireCommand:Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {

        }

        public override string Execute()
        {
            string unitType = this.Data[1];

            this.repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}
