using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;

namespace BashSoft.IO.Commands
{
    [Alias("mkdir")]
    public class MakeDirectoryCommand:Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;

        public MakeDirectoryCommand(string input, string[] data) :
            base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string folderName = this.Data[1];

                this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
