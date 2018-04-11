using System;
using System.Collections.Generic;
using System.Text;


   public class CreateCommand:Command
    {
    [Injection]
    private WeaponRepository repository;
    [Injection]
    private WeaponFactory weaponFactory;

    public override void Execute(string[] data)
    {
        string[] weaponTypeRarityLevelPair = data[0].Split();

        string rarityLevelAsString = weaponTypeRarityLevelPair[0];

        string weaponType = weaponTypeRarityLevelPair[1];

        string weaponName = data[1];

        this.repository.AddWeapon(weaponFactory.CreateWeapon(rarityLevelAsString,weaponType,weaponName));
    }

}

