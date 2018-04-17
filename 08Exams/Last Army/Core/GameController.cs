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
        return new Output().GiveOutput(army, wearHouse, this.MissionControllerField);
    }
    private void AddAmmunitions(IAmmunition ammunition, int number)
    {    
            this.wearHouse.AddWeapon(ammunition, number);      
    }

    private void AddSoldierToArmy(ISoldier soldier, string type)
    {
        foreach (var weaponString in soldier.WeaponsAllowed)
        {
            if (!this.wearHouse.Weapons.ContainsKey(weaponString))
            {
                throw new ArgumentException($"There is no weapon for {soldier.GetType().Name} {soldier.Name}!");
            }
            if (this.wearHouse.Weapons[weaponString].Count==0)
            {
                throw new ArgumentException($"There is no weapon for {soldier.GetType().Name} {soldier.Name}!");
            }
        }

        FindWeaponsInRepo(soldier);

        this.army.AddSoldier(soldier);

    }

    private void FindWeaponsInRepo(ISoldier soldier)
    {
        foreach (var weapon in soldier.WeaponsAllowed)
        {
            if (this.wearHouse.Weapons[weapon].Count > 0)
            {
                IAmmunition weaponToAdd = this.wearHouse.Weapons[weapon].First();

                if (soldier.GetWeapon(weaponToAdd))
                {
                    this.wearHouse.RemoveWeapon(weaponToAdd);
                }
            }
        }
    }
}
