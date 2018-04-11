using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
    public class Logger : ILogger
    {
            

       public  ICollection<IAppender> appenders { get;}

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public Logger()
        {
            this.appenders = new List<IAppender>();
        }
        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.ErrorLevel<=error.errorLevel)
                {
                    appender.Append(error);
                    appender.IncreaseMessageNumber();
                }
            }
        }

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }
    }
}
