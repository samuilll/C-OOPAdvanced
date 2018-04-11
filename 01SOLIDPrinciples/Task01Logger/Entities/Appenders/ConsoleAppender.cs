using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
  public  class ConsoleAppender:Appender
    {
        public ConsoleAppender(ILayout layout,ErrorLevel errorLevel):base(layout,errorLevel)
        {
        }

        public override void Append(IError error)
        {
            string formattedError = this.layout.GetInfo(error);

            Console.WriteLine(formattedError);
        }
    }
}
