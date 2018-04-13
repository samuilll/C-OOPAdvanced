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
    [Alias("ls")]
  public  class TraverseFoldersCommand:Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;

        public TraverseFoldersCommand(string input, string[] data) : 
            base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 1)
            {
                this.InputOutputManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;

                bool hasParsed = int.TryParse(this.Data[1], out depth);
                if (hasParsed)
                {
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new InvalidCommandException(this.Input);
                }
            }
            else
            {
                DisplayInvalidCommandMessage(this.Input);
            }
        }
    }
}
