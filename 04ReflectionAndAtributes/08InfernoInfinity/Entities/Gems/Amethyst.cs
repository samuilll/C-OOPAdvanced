using System;
using System.Collections.Generic;
using System.Text;


  public  class Amethyst:Gem
    {
    public Amethyst(Clarity clarity) : base(strength, agility, vitality,clarity)
    {

    }
    private const int strength = 2;
    private const int agility = 8;
    private const int vitality = 4;
}

