using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Contracts
{
  public  interface IRequester
    {
        void GetStudentScoresFromTheCourse(string courseName, string studentName);
        void GetAllStudentsFromTheCourse(string courseName);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);


    }
}
