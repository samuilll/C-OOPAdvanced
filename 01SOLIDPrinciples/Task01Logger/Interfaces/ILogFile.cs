using System;
using System.Collections.Generic;
using System.Text;

namespace Task01Logger.Interfaces
{
  public  interface ILogFile
    {
        string Path { get; }
        int Size { get; }
        void WriteToFile(string text);
    }
}
