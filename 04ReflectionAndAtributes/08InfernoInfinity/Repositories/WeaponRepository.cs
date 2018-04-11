using System;
using System.Collections.Generic;
using System.Text;


public class WeaponRepository
{
    public WeaponRepository()
    {
        this.weapons = new List<Weapon>();
    }

    private List<Weapon> weapons;

    public IReadOnlyList<Weapon> Weapons
    {
        get
        {
            return (IReadOnlyList<Weapon>)weapons;
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        this.weapons.Add(weapon);
    }
}

