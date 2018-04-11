using Ex04WorkForce.Contracts;
using Ex04WorkForce.Factories;
using Ex04WorkForce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04WorkForce.Controllers
{
    public class Engine
    {
        private EmployeeFactory employeeFactory = new EmployeeFactory();
        private JobFactory jobFactory = new JobFactory();
        private EmployeeRepository employeesRepo = new EmployeeRepository();
        private JobsRepository jobsRepo = new JobsRepository();

        public void Run()
        {

            while (true)
            {
                string[] args = Console.ReadLine().Split();

                string command = args[0];

                if (command == "End")
                {
                    break;
                }

                args = args.Skip(1).ToArray();

                this.InterpredCommand(command, args);
            }
        }

        private void InterpredCommand(string command, string[] args)
        {
            switch (command)
            {
                case "StandardEmployee":
                    {
                        string name = args[0];
                        this.employeesRepo.AddEmployee(this.employeeFactory.CreateEmployee("StandardEmployee", name));
                        break;
                    }
                case "PartTimeEmployee":
                    {
                        string name = args[0];
                        this.employeesRepo.AddEmployee(this.employeeFactory.CreateEmployee("PartTimeEmployee", name));
                        break;
                    }
                case "Job":
                    {
                        string employeeName = args[2];
                        string jobName = args[0];
                        int jobHours = int.Parse(args[1]);

                        IEmployee employee = employeesRepo.Employees.First(e => e.Name == employeeName);
                        IJob job = this.jobFactory.CreateJob(jobName, jobHours, employee);
                        this.jobsRepo.AddJob(job);
                        break;
                    }
                case "Pass":
                    {
                        this.jobsRepo.PastWeek();
                        break;
                    }
                case "Status":
                    {
                        Console.WriteLine(this.jobsRepo.GetStatus());
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
