using System;
using System.Collections.Generic;
using System.Text;


  public  class Axe:Weapon
    {
    public Axe(RarityLevel rarityLevel,string name) : base(minDamageConst, maxDamageConst, rarityLevel, socketsNumConst,name)
    {
    }
    private const int minDamageConst = 5;
    private const int maxDamageConst = 10;
    private const int socketsNumConst = 4;


}

