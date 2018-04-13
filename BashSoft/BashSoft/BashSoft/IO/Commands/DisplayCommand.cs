using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO.Commands
{
    [Alias("display")]
    public class DisplayCommand : Command
    {
        public DisplayCommand(string input, string[] data) :
            base(input, data)
        {
        }

        [Inject]
        private IDatabase Repository;

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = this.Data[1];
            string sortType = this.Data[2];

            if (entityToDisplay.ToLower() == "students")
            {
                IComparer<IStudent> comparator = CreateStudentComparer(sortType);
                ISimpleOrderedBag<IStudent> students = this.Repository.GetAllStudentsSorted(comparator);
                OutputWriter.WriteMessageOnNewLine(students.JoinWith(Environment.NewLine));

            }
            else if (entityToDisplay.ToLower() == "courses")
            {
                IComparer<ICourse> comparator = CreateCourseComparer(sortType);
                ISimpleOrderedBag<ICourse> courses = this.Repository.GetAllCoursesSorted(comparator);
                OutputWriter.WriteMessageOnNewLine(courses.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ICourse> CreateCourseComparer(string sortType)
        {
            if (sortType.ToLower() == "ascending")
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseOne.CompareTo(courseTwo));
            }
            else if (sortType.ToLower() == "descending")
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseTwo.CompareTo(courseOne));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<IStudent> CreateStudentComparer(string sortType)
        {
            if (sortType.ToLower()=="ascending")
            {
               return Comparer<IStudent>.Create((studentOne, studentTwo) => studentOne.CompareTo(studentTwo));
            }
          else  if (sortType.ToLower() == "descending")
            {
              return  Comparer<IStudent>.Create((studentOne, studentTwo) => studentTwo.CompareTo(studentOne));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
