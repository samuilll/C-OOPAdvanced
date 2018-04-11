using System;
using System.Collections.Generic;
using System.Text;

namespace Task01Logger.Interfaces
{
   public interface IError
    {
        DateTime dateTime { get; }

        string Message { get; }

       ErrorLevel errorLevel { get; }
    }
}
