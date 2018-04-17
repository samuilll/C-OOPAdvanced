using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class GameController
{
    private IArmy army;
    private IWareHouse wearHouse;
    private MissionController missionControllerField;
    private ISoldierFactory soldierFactory = new SoldiersFactory();
    private IMissionFactory missionFactory = new MissionFactory();
    private IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
    private StringBuilder result;

    public StringBuilder Result
    {
        get { return result; }
    }
    public GameController(StringBuilder result)
    {
        this.result = result;
        this.army = new Army();
        this.wearHouse = new WareHouse();
        this.MissionControllerField = new MissionController(army,wearHouse);
    }

    public MissionController MissionControllerField
    {
        get { return missionControllerField; }
        set { missionControllerField = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        var command = data[0];

        data = data.Skip(1).ToArray();

        var commandName = "Parse" + command + "Command";
        var method = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(m=>m.Name==commandName);

        try
        {
            method.Invoke(this, new object[] { data });

        }
        catch (TargetInvocationException ex)
        {
            throw ex.InnerException;
        }
    }

    private void ParseSoldierCommand(string[] data)
    {
         
        if (data.Length == 2)
        {
            string name = data[1];
            this.army.RegenerateTeam(name);
        }
        else
        {
          string  type = data[0];
          string  name = data[1];
           int age = int.Parse(data[2]);
           int experience = int.Parse(data[3]);
          double  endurance = double.Parse(data[4]);
            ISoldier soldier = soldierFactory.CreateSoldier(type, name, age, experience, endurance);
            AddSoldierToArmy(soldier, type);
        }

    }

    private void ParseWareHouseCommand(string[] data)
    {
        string name = data[0];

        int number = int.Parse(data[1]);

        AddAmmunitions(ammunitionFactory.CreateAmmunition(name), number);
    }

    private void ParseMissionCommand(string[] data)
    {
        var missionType = data[0];
        var neededPoints = double.Parse(data[1]);
        this.result.AppendLine(this.MissionControllerField.PerformMission(this.missionFactory.CreateMission(missionType, neededPoints)));
    }

    public string RequestResult()
    {
        this.missionControllerField.FailMissionsOnHold();

        var result = new StringBuilder();

        result.AppendLine("Results:");
        result.AppendLine($"Successful missions - {missionControllerField.SuccessMissionCounter}");
        result.AppendLine($"Failed missions - {missionControllerField.FailedMissionCounter}");
        result.AppendLine("Soldiers:");

        List<ISoldier> soldiers = new List<ISoldier>();

        soldiers = army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();

        foreach (var soldier in soldiers)
        {
            result.AppendLine(soldier.ToString());
        }
        return result.ToString().TrimEnd('\n');
    }
    private void AddAmmunitions(IAmmunition ammunition, int number)
    {    
            this.wearHouse.AddWeapon(ammunition, number);      
    }

    private void AddSoldierToArmy(ISoldier soldier, string type)
    {
        var weaponsAsString = soldier.Weapons.Keys.ToList();

        foreach (var weaponAsString in weaponsAsString)
        {
            if (!this.wearHouse.Weapons.ContainsKey(weaponAsString))
            {
                throw new ArgumentException($"There is no weapon for {soldier.GetType().Name} {soldier.Name}!");
            }
            if (this.wearHouse.Weapons[weaponAsString].Count == 0)
            {
                throw new ArgumentException($"There is no weapon for {soldier.GetType().Name} {soldier.Name}!");
            }
            if (this.wearHouse.Weapons[weaponAsString].Count > 0)
            {
                IAmmunition weaponToAdd = this.wearHouse.Weapons[weaponAsString].First();

                if (soldier.Weapons[weaponAsString] == null)
                {
                    soldier.Weapons[weaponAsString] = weaponToAdd;
                    this.wearHouse.RemoveWeapon(weaponToAdd);
                }           
            }
        }
        
        this.army.AddSoldier(soldier);
    }

    //private void FindWeaponsInRepo(ISoldier soldier)
    //{
    //    foreach (var weapon in soldier.WeaponsAllowed)
    //    {
    //        if (this.wearHouse.Weapons[weapon].Count > 0)
    //        {
    //            IAmmunition weaponToAdd = this.wearHouse.Weapons[weapon].First();

    //            if (soldier.GetWeapon(weaponToAdd))
    //            {
    //                this.wearHouse.RemoveWeapon(weaponToAdd);
    //            }
    //        }
    //    }
    //}
}
