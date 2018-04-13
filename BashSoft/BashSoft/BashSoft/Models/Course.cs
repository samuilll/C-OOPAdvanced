﻿using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Models
{
    public class Course:ICourse
    {

        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.name = value;
            }
        }

        private Dictionary<string, IStudent> studentsByName;

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return this.studentsByName; }
        }

        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this.studentsByName.Add(student.UserName, student);
        }

        public int CompareTo(ICourse other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
