using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Contracts
{
  public  interface IStudent:IComparable<IStudent>
    {
        string UserName { get; }

         IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        void EnrollInCourse(ICourse course);

         IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        void SetMarkOnCourse(string courseName, params int[] scores);

    }
}
