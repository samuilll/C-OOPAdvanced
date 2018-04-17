using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


  public  class MissionFactory:IMissionFactory
    {
        public IMission CreateMission(string missionType, double scoreToComplete)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == missionType);


            IMission mission = (IMission)Activator.CreateInstance(type,scoreToComplete );

            return mission;
        }
    }

