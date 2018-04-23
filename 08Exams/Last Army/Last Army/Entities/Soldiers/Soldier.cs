using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    
    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    protected int EnduranceIncrement { get; set; }

    protected Soldier(string name, int age, double experience, double endurance)
    {
        Name = name;
        Age = age;
        Experience = experience;
        Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
        this.InitializeWeapons();
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance { get; protected set; }

    public virtual double OverallSkill { get; protected set;}

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public void Regenerate()
    {
        this.Endurance+=(this.Age+this.EnduranceIncrement);

        if (this.Endurance>100)
        {
            this.Endurance = 100;
        }
    }

    public void CompleteMission(IMission mission)
    {
        AmmunitionRevision(mission.WearLevelDecrement);
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;
    }
    private void InitializeWeapons()
    {
        foreach (var weaponString in this.WeaponsAllowed)
        {
            if (!this.Weapons.ContainsKey(weaponString))
            {
                this.Weapons[weaponString] = null;
            }
        }
    }
}