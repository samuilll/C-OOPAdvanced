using System.Collections.Generic;

    public interface IWareHouse
    {
         Dictionary<string, List<IAmmunition>> Weapons { get;}

         void AddWeapon(IAmmunition weapon, int count);
        void RemoveWeapon(IAmmunition weapon);
        void EquipArmy(IArmy army);
    }
