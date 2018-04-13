using BashSoft.Judge;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
using BashSoft.Contracts;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("open")]
    public class OpenFileCommand:Command
    {
        public OpenFileCommand(string input, string[] data)
            :base(input,data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];

                Process.Start(SessionData.CurrentPath + "\\" + fileName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
