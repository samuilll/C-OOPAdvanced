using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public  class Output
    {
        public  string GiveOutput( IArmy army,
            IWareHouse wearHouse, MissionController missionControllerField)
        {
            var result = new StringBuilder();
            result.AppendLine("Results:");
            result.AppendLine($"Successful missions - {missionControllerField.SuccessMissionCounter}");
            result.AppendLine($"Failed missions - {missionControllerField.FailedMissionCounter}");
            result.AppendLine("Soldiers:");

            List<ISoldier> soldiers = new List<ISoldier>();

            soldiers = army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();

            foreach (var soldier in soldiers)
            {
                result.AppendLine($"{soldier.Name} - {soldier.OverallSkill}");
            }

            return result.ToString().TrimEnd('\n');

        }
    }
