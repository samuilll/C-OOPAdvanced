using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


   public class WeaponFactory
    {
    public Weapon CreateWeapon(string rarityLevelAsString, string weaponType, string weaponName)
    {
        if (!Enum.TryParse<RarityLevel>(rarityLevelAsString, out RarityLevel rarityLevel))
        {
            throw new ArgumentException("There is no such a rarity level!");
        }

        Type typeToCreate = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == weaponType);

        if (typeToCreate==null)
        {
            throw new ArgumentException("There is no such a weapon");
        }

        Weapon weapon = (Weapon)Activator.CreateInstance(typeToCreate, new object[] { rarityLevel,weaponName});

        return weapon;
    }
    }

