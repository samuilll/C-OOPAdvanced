using Ex04WorkForce.Contracts;
using Ex04WorkForce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Repositories
{
   public class JobsRepository
    {


        private List<IJob> jobs;

        public JobsRepository()
        {
            this.jobs = new List<IJob>();
        }

        public IReadOnlyCollection<IJob> Jobs
        {
            get
            {
                return (IReadOnlyCollection<IJob>)jobs;
            }
        }

        public void AddJob(IJob job)
        {
            this.jobs.Add(job);
        }
        public void PastWeek()
        {
            for (int i = 0; i < this.jobs.Count; i++)
            {
                IJob currentJob = this.jobs[i];

                currentJob.SubstractHours();

                if (currentJob.HoursOfWorkRequired<=0)
                {
                    Console.WriteLine($"Job {currentJob.Name} done!"); 

                    this.jobs.RemoveAt(i);

                    i--;
                }
            }
        }

        public string GetStatus()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var job in this.jobs)
            {
                builder.AppendLine(job.ToString());
            }

            return builder.ToString().TrimEnd('\n', '\r');
        }

    }
}
