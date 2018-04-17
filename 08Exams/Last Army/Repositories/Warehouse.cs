using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class WareHouse:IWareHouse
    {

        private Dictionary<string,List<IAmmunition>> weapons;

        public WareHouse()
        {
            this.weapons = new Dictionary<string, List<IAmmunition>>();
        }


        public Dictionary<string, List<IAmmunition>> Weapons => this.weapons;
 
        public void AddWeapon(IAmmunition weapon, int count)
        {
            if (!this.weapons.ContainsKey(weapon.Name))
            {
                this.weapons[weapon.Name] = new List<IAmmunition>();
            }
            for (int i = 0; i < count; i++)
            {
                this.weapons[weapon.Name].Add(weapon);
            }
        }

        public void EquipArmy(IArmy army)
        {
        for (int i = 0; i < army.Soldiers.Count; i++)
        {
            var soldier = army.Soldiers[i];

            var weaponsAsString = soldier.Weapons.Keys.ToList();

            foreach (var weaponAsString in  weaponsAsString )
            {                    
                if (this.Weapons[weaponAsString].Count > 0)
                {
                    IAmmunition weaponToAdd = this.Weapons[weaponAsString].First();

                    if (soldier.Weapons[weaponAsString]==null)
                    {
                        soldier.Weapons[weaponAsString]=weaponToAdd;
                        this.RemoveWeapon(weaponToAdd);
                        continue;
                    }

                   else if (soldier.Weapons[weaponAsString].WearLevel <= 0)
                    {
                        soldier.Weapons[weaponAsString] = weaponToAdd;
                        this.RemoveWeapon(weaponToAdd);
                        continue;
                    }
                }
            }
        }
        }

        public void RemoveWeapon(IAmmunition weapon)
        {
        this.Weapons[weapon.Name].Remove(weapon);
            
        }

    }

