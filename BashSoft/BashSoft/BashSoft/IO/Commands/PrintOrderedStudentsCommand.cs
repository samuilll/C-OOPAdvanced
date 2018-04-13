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
    [Alias("order")]
    public class PrintOrderedStudentsCommand:Command
    {
        [Inject]
        private IDatabase Repository;

        public PrintOrderedStudentsCommand(string input, string[] data) :
            base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 5)
            {
                string coursename = this.Data[1];
                string comparison = this.Data[2].ToLower();
                string takeCommand = this.Data[3].ToLower();
                string takeQuantity = this.Data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, coursename, comparison);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string coursename, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.Repository.OrderAndTake(coursename, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = Int32.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.Repository.OrderAndTake(coursename, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
        }
    }
}
