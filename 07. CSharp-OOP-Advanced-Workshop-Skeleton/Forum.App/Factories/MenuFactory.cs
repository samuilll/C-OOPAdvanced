using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == menuName);

            if (menuType==null)
            {
                throw new ArgumentException("Menu not found");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new ArgumentException($"{menuType} is not a menu!");
            }

            ParameterInfo[] parameters = menuType.GetConstructors().First().GetParameters();
            object[] arguments = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                arguments[i] = this.serviceProvider.GetService(parameters[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, arguments);

            return menu;
        }
    }
}
