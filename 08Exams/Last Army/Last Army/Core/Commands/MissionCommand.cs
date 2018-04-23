using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MissionCommand : Command
{
    private IWriter writer;
    private IMissionFactory missionFactory;
    private MissionController missionControllerField;
    public MissionCommand(IReadOnlyList<string> arguments,IWriter writer,IMissionFactory missionFactory,MissionController missionController)
      : base(arguments)
    {
        this.writer = writer;
        this.missionFactory = missionFactory;
        this.missionControllerField = missionController;
    }
    public override void Execute()
    {
        string missionName = Arguments[0];
        double scoreToComplete = double.Parse(Arguments[1]);

        IMission mission = this.missionFactory.CreateMission(missionName, scoreToComplete);

        this.writer.AddMessage(this.missionControllerField.PerformMission(mission));
    }
}

