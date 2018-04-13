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
    [Alias("filter")]   
    public class PrintFilteredStudentsCommand : Command
    {
        [Inject]
        private IDatabase Repository;

        public PrintFilteredStudentsCommand(string input, string[] data) :
            base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 5)
            {
                string coursename = this.Data[1];
                string filter = this.Data[2].ToLower();
                string takeCommand = this.Data[3].ToLower();
                string takeQuantity = this.Data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, coursename, filter);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string coursename, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.FilerAndTake(coursename, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = Int32.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.Repository.FilerAndTake(coursename, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }

            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }
    }
}
