using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IUnitFactory unitFactory;
        [Inject]
        private IRepository repository;

        public AddCommand(string[] data) : base(data)
        {
            this.unitFactory = new UnitFactory();

        }

        public override string Execute()
        {
            string result = this.AddUnitCommand(this.Data);

            return result;
        }

        private string AddUnitCommand(string[] data)
        {
            string unitType = data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
