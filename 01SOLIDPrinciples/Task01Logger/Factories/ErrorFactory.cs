using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Task01Logger.Entities;
using Task01Logger.Interfaces;

namespace Task01Logger.Factories
{
   public class ErrorFactory
    {

        public IError CreateError(string dateTimeAsString,string errorLevelAsString, string message)
        {
            const string dateformat = "M/d/yyyy h:mm:ss tt";

            Enum.TryParse<ErrorLevel>(errorLevelAsString, out var errorLevel);

            var dateTime = DateTime.ParseExact(dateTimeAsString, dateformat, CultureInfo.InvariantCulture);

            return new Error(dateTime,errorLevel, message);
        }
    }
}
