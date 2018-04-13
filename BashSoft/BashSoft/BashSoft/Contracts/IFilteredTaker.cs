using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Contracts
{
  public  interface IFilteredTaker
    {
        void FilerAndTake(string courseName, string givenFilter, int? studentsToTake = null);
    }
}
