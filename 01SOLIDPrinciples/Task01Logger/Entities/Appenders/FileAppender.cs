using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
    public class FileAppender : Appender
    {
        private LogFile file;
        public FileAppender(ILayout layout,ErrorLevel errorLevel):base(layout,errorLevel)
        {
            this.file = new LogFile();
        }

        private int fileSize => File.ReadAllText(this.file.Path).ToCharArray().Where(c=>char.IsLetter(c)).Select(c => (int)c).Sum();
        public override void Append(IError error)
        {
            string formattedError = this.layout.GetInfo(error);
            File.AppendAllText(this.file.Path,formattedError+Environment.NewLine);
        }

        public override string ToString()
        {
            return base.ToString()+$", File size: {this.fileSize}";
        }
    }
}
