using BashSoft.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Repository
{
    public  class RepositorySorter:IDataSorter
    {
        public  void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            if (comparison == "ascending")
            {
                PrintStudents(studentsMarks
                    .OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(studentsMarks
                    .OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));

            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private  void PrintStudents(Dictionary<string,double> studentsSorted)
        {
            foreach (var pair in studentsSorted)
            {
                OutputWriter.PrintStudent(pair);
            }
        }


    }
}
