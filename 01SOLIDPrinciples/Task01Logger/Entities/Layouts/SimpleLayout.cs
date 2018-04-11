using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
    public class SimpleLayout : Layout
    {
      
        const string dateformat = "M/d/yyyy h:mm:ss tt";

        const string format = "{0} - {1} - {2}";

        public override string GetInfo(IError error)
        {

            string dateString = error.dateTime.ToString(dateformat,CultureInfo.InvariantCulture);
            return string.Format(format, dateString, error.errorLevel, error.Message);
        }

        
    }
}
