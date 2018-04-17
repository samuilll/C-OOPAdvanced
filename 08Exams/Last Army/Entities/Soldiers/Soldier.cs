using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.InitializeWeapons();
    }

    private void InitializeWeapons()
    {
        foreach (var weapon in this.WeaponsAllowed)
        {
            this.Weapons[weapon] = null;
        }
    }

    public IDictionary<string, IAmmunition> Weapons { get; protected set; } = new Dictionary<string, IAmmunition>();

    public abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; protected set; }

    public double Multiplier { get; protected set; }

    public int Age { get; protected set; }

    public double Experience { get; protected set; }

    public double Endurance { get; protected set; }

    public double OverallSkill => (this.Age + this.Experience) * this.Multiplier;

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.All(w=>w!=null);

        if (!hasAllEquipment)
        {
            return false;
        }

        if (this.Weapons.Values.Any())
        {

        }
        foreach (var pair in this.Weapons)
        {
            if (pair.Value==null || pair.Value.WearLevel<=0 )
            {
                return false;
            }
        }

        return true;
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

    public override string ToString() => $"{this.Name} - {this.OverallSkill}";

    public virtual void Regenerate()
    {
        this.Endurance += (10 + this.Age);

        if (this.Endurance > 100)
        {
            this.Endurance = 100;
        }
    }

    public void CompleteMission(IMission mission)
    {
        this.AmmunitionRevision(mission.WearLevelDecrement);
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;
    }

    
}