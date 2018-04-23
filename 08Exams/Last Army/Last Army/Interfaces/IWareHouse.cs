using System.Collections;
using System.Collections.Generic;

public interface IWareHouse
{
      Dictionary<string, int> Weapons { get;}

    void AddAmmunitions(string weaponName,int count);

    void EquipArmy(IArmy army);
}