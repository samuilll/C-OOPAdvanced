using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class Ranker:Soldier
    {
    private const double OverallSkillMiltiplier = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet"
        };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }
     public override double OverallSkill=> (this.Age + this.Experience) * OverallSkillMiltiplier;

    protected override IReadOnlyList<string> WeaponsAllowed => (IReadOnlyList<string>)this.weaponsAllowed;
}
