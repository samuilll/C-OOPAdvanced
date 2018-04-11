using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
    public class Error : IError
    {
        public Error(DateTime dateTime,ErrorLevel errorLevel,string message)
        {
            this.dateTime = dateTime;
            this.Message = message;
            this.errorLevel = errorLevel;
        }
        public DateTime dateTime { get; }

        public string Message { get;}

       public ErrorLevel errorLevel { get; }
    }
}
