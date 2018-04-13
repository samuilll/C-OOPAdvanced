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
    [Alias("cdRel")]
   public class ChangeRelativePathCommand:Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data) :
            base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string relPath = this.Data[1];
                this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
