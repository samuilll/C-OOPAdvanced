using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class AddCommand:Command
    {

    [Injection]
    private WeaponRepository repository;
    [Injection]
    private GemFactory gemFactory;

    public override void Execute(string[] data)
    {
        string weaponName = data[0];
        int index = int.Parse(data[1]);
        string clarityAsString = data[2].Split().First();
        string typeOfGem = data[2].Split().Last();
       
        Weapon weapon = this.repository.Weapons.FirstOrDefault(w => w.Name == weaponName);

        if (weapon==null)
        {
            throw new ArgumentException("There is no such a weapon in the repository!");
        }
        Gem gem = this.gemFactory.CreateGem(clarityAsString, typeOfGem);

        weapon.AddGem(gem,index);
    }

   
}

