using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class PrintCommand:Command
    {
    [Injection]
    private WeaponRepository repository;

    public override void Execute(string[] data)
    {
        string weaponName = data[0];

        Weapon weapon = this.repository.Weapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon == null)
        {
            throw new ArgumentException("There is no such a weapon in the repository!");
        }

        Console.WriteLine(weapon);
    }
}

