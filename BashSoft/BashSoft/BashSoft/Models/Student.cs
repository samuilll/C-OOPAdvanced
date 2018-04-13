﻿using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Models
{
    public class Student:IStudent
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.userName = value;
            }
        }

        private Dictionary<string, ICourse> enrolledCourses;

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        private Dictionary<string, double> marksByCourseName;

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public Student(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public void EnrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }

        public int CompareTo(IStudent other)
        {
            return this.UserName.CompareTo(other.UserName);
        }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}
