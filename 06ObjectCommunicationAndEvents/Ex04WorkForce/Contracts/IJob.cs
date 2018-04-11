using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Contracts
{
   public interface IJob
    {
        IEmployee Employee { get; }

        string Name { get; }

        int HoursOfWorkRequired { get; }

        void SubstractHours();

    }
}
