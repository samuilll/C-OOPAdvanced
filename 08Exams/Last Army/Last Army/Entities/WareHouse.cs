using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WareHouse : IWareHouse
{
    public WareHouse()
    {
        Weapons = new Dictionary<string, int>();
    }

    public Dictionary<string, int> Weapons { get; private set; }

    public void AddAmmunitions(string weaponName, int count)
    {
        if (!this.Weapons.ContainsKey(weaponName))
        {
            this.Weapons[weaponName] = 0;
        }
        for (int i = 0; i < count; i++)
        {
            this.Weapons[weaponName] += 1;
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            var weaponsNeeded = new List<string>();

            foreach (var pair in soldier.Weapons)
            {
                if (pair.Value==null)
                {
                    weaponsNeeded.Add(pair.Key);
                }
            }

            foreach (var weaponNeedName in weaponsNeeded)
            {
                if (this.Weapons.ContainsKey(weaponNeedName) && this.Weapons[weaponNeedName]>0)
                {
                    soldier.Weapons[weaponNeedName] = new AmmunitionFactory().CreateAmmunition(weaponNeedName);
                    this.Weapons[weaponNeedName]--;
                }
            }

        }
    }


}

