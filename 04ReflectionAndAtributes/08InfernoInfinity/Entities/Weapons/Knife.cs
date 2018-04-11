using System;
using System.Collections.Generic;
using System.Text;


   public class Knife:Weapon
    {
    public Knife(RarityLevel rarityLevel,string name) : base(minDamageConst, maxDamageConst, rarityLevel, socketsNumConst,name)
    {
    }
    private const int minDamageConst = 3;
    private const int maxDamageConst = 4;
    private const int socketsNumConst = 2;

}

