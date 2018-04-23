using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SoldierCommand : Command
{
    private IArmy army;
    private IWareHouse wareHouse;
    private ISoldierFactory soldierFactory;
    private IWriter writer;
    private IAmmunitionFactory ammoFactory;
    public SoldierCommand(IReadOnlyList<string> arguments,IArmy army,IWareHouse wareHouse,
        ISoldierFactory soldierFactory,IWriter writer,IAmmunitionFactory ammoFactory)
        : base(arguments)

    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.soldierFactory = soldierFactory;
        this.writer = writer;
        this.ammoFactory = ammoFactory;
    }
    public override void Execute()
    {
        string type = string.Empty;
        string name = string.Empty;

        if (this.Arguments.Count == 2)
        {
            type = Arguments[1];

            this.army.RegenerateTeam(type);
        }
        else
        {
            type = Arguments[0];
            name = Arguments[1];
            var age = int.Parse(Arguments[2]);
            var experience = double.Parse(Arguments[3]);
            var endurance = double.Parse(Arguments[4]);

            ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

            if (CanSoldierJoinTheTeam(soldier))
            {
                this.army.AddSoldier(soldier);
            }
            else
            {
                this.writer.AddMessage(string.Format(OutputMessages.CannotJoinTeam, soldier.Name));
            }

        }
    }
    private bool CanSoldierJoinTheTeam(ISoldier soldier)
    {
        var weaponsAllowed = new List<string>();

        foreach (var weapon in soldier.Weapons.Keys)
        {
            weaponsAllowed.Add(weapon);
            if (!this.wareHouse.Weapons.ContainsKey(weapon) || this.wareHouse.Weapons[weapon] == 0)
            {
                return false;
            }
        }

        foreach (var stringWeapon in weaponsAllowed)
        {
            IAmmunition ammunition = this.ammoFactory.CreateAmmunition(stringWeapon);
            soldier.Weapons[stringWeapon] = ammunition;
            this.wareHouse.Weapons[stringWeapon]--;
        }

        return true;
    }
}

