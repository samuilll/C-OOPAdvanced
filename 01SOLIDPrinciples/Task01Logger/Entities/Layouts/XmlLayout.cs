using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities.Layouts
{
    public class XmlLayout : Layout
    {
       private const string dateformat = "M/d/yyyy h:mm:ss tt";

        public override string GetInfo(IError error)
        {
            StringBuilder builder = new StringBuilder();

            string dateString = error.dateTime.ToString(dateformat, CultureInfo.InvariantCulture);

            builder.AppendLine("<log>");
            builder.AppendLine($"<date>{dateString}</date>");
            builder.AppendLine($"<level>{error.errorLevel}</level>");
            builder.AppendLine($"<message>{error.Message}</message>");
            builder.Append("</log>");

            return builder.ToString();
        }
    }
}

