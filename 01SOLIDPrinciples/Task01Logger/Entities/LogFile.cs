using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
   public class LogFile:ILogFile
    {
        public string Path =>"data.txt";

        public int Size => throw new NotImplementedException();

        public void Log()
        {

        }

        public void WriteToFile(string text)
        {
            File.WriteAllText(this.Path,text);
        }       
    }
}
