using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EndCommand : Command
{
    private const string resultString = "Results:";
    private const string soldiersResultString = "Soldiers:";

    private IWriter writer;
    private MissionController missionControllerField;
    private IArmy army;

    public EndCommand(IReadOnlyList<string> arguments, IWriter writer,MissionController missionController,IArmy army)
        : base(arguments)

    {
        this.writer = writer;
        this.missionControllerField = missionController;
        this.army = army;
    }
    public override void Execute()
    {
        this.missionControllerField.FailMissionsOnHold();
        writer.AddMessage(resultString);
        writer.AddMessage(string.Format(OutputMessages.SuccessfulMissions, this.missionControllerField.SuccessMissionCounter));
        writer.AddMessage(string.Format(OutputMessages.FailedMissions, this.missionControllerField.FailedMissionCounter));
        writer.AddMessage(soldiersResultString);
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.AddMessage(soldier.ToString());
        }
    }
}

