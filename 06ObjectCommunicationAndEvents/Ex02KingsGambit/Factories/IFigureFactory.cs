using Ex02KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ex02KingsGambit.Factories
{
   public class IFigureFactory
    {
        public IFigure CreateFigure(string typeName,string figureName)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);

            if (type==null)
            {
                throw new ArgumentException("No such a soldier");
            }

            IFigure figure = (IFigure)Activator.CreateInstance(type,new object[] { figureName});

            return figure;
        }
    }
}
