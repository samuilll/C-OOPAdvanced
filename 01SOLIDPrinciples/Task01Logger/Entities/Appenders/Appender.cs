using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout,ErrorLevel errorLevel)
        {
            this.layout = layout;
            this.ErrorLevel = errorLevel;
        }
        public ILayout layout { get; }

        public ErrorLevel ErrorLevel { get;}

        public virtual void Append(IError error)
        {
        }

        private int errorCount;

        public int ErrorCount
        {
            get { return errorCount; }
            private set { errorCount = value; }
        } 

        public override string ToString()
        {
            string result= $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ErrorLevel}, Messages appended: {this.ErrorCount}";
            return result;
        }

        public void IncreaseMessageNumber()
        {
            this.ErrorCount++;
        }
    }
}
