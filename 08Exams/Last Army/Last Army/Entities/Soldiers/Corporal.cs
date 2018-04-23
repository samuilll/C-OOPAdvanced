using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class Corporal:Soldier
    {
    private const double OverallSkillMiltiplier = 2.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet",
            "MachineGun",
            "Knife"
        };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }
    public override double OverallSkill => (this.Age + this.Experience) * OverallSkillMiltiplier;
    protected override IReadOnlyList<string> WeaponsAllowed => (IReadOnlyList<string>)this.weaponsAllowed;
}

