namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {

        public IUnit CreateUnit(string unitType)
        {
            Assembly assebly = Assembly.GetExecutingAssembly();

            Type model = assebly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Is not");
            }
            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException("Is not");
            }

            IUnit unit = (IUnit)Activator.CreateInstance(model);

            return unit;
        }
    }
}
