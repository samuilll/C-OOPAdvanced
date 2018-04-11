using System;
using System.Collections.Generic;
using System.Text;


 public   class Emerald:Gem
    {
    public Emerald(Clarity clarity) : base(strength, agility, vitality,clarity)
    {

    }
    private const int strength = 1;
    private const int agility = 4;
    private const int vitality = 9;
}

