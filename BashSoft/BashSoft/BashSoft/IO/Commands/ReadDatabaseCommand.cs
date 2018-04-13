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
    [Alias("readDb")]
    public class ReadDatabaseCommand:Command
    {
        [Inject]
        private IDatabase Repository;

        public ReadDatabaseCommand(string input, string[] data) :
            base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];
                this.Repository.LoadData(fileName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
