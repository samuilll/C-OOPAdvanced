using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Entities;
using Task01Logger.Entities.Layouts;
using Task01Logger.Interfaces;

namespace Task01Logger.Factories
{
    public class LayoutFactory
    {

        public ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    {
                        return new SimpleLayout();

                    }
                case "XmlLayout":
                    {
                        return new XmlLayout();
                    }
            }

            throw new ArgumentException(layoutType,"InvalidParameter");
        }
    }
}
