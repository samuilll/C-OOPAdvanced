using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Entities;
using Task01Logger.Interfaces;

namespace Task01Logger.Factories
{
   public class AppenderFactory
    {
        public IAppender CreateAppender(IList<string> args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            string errorLevel;

            ILayout layout = new LayoutFactory().CreateLayout(layoutType);

            if (args.Count<3)
            {
                errorLevel = "INFO";
            }
            else
            {
                errorLevel = args[2];
            }

            if (!Enum.TryParse<ErrorLevel>(errorLevel,out ErrorLevel result))
            {
                throw new ArgumentException("Invalid error level!");
            }
            switch (appenderType)
            {
                case "ConsoleAppender":
                    {
                        return new ConsoleAppender(layout, result);
                    }
                case "FileAppender":
                    {
                        return new FileAppender(layout, result);
                    }
            }

            throw new ArgumentException("Invalid input!");
        }
    }
}
