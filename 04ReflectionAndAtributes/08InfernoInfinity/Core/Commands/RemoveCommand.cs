using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class RemoveCommand:Command
    {
    [Injection]
    private WeaponRepository repository;

    public override void Execute(string[] data)
    {
        string weaponName = data[0];
        int index = int.Parse(data[1]);

        Weapon weapon = this.repository.Weapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon == null)
        {
            throw new ArgumentException("There is no such a weapon in the repository!");
        }

        weapon.RemoveGem(index);
    }
}

