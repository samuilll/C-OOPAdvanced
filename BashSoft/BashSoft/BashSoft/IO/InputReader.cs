using BashSoft.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO
{
   public class InputReader:IInputReader
    {
        private string endCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {

            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();

                if (input==endCommand)
                {
                    break;
                }

                this.interpreter.InterpredCommand(input);
            }            
        }
    }
}
