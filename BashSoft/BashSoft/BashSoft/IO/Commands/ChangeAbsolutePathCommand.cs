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
    [Alias("cdAbs")]
   public class ChangeAbsolutePathCommand:Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data) :
            base(input, data)
        {
        }

        public override void Execute()
        {

            if (this.Data.Length == 2)
            {
                string absolutePath = this.Data[1];
                this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
