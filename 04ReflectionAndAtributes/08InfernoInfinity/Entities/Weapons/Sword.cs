using System;
using System.Collections.Generic;
using System.Text;


  public  class Sword:Weapon
    {
    public Sword(RarityLevel rarityLevel,string name) : base(minDamageConst, maxDamageConst, rarityLevel, socketsNumConst,name)
    {
    }
    private const int minDamageConst = 4;
    private const int maxDamageConst = 6;
    private const int socketsNumConst = 3;

}

