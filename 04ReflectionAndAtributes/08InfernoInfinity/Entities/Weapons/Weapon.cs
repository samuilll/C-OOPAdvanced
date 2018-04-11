using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Inferno]
public abstract class Weapon
{

    
    protected Weapon(int minDamage, int maxDamage, RarityLevel rarityLevel, int socketNumber,string name)
    {
        this.Name = name;
        this.RarityLevel = rarityLevel;
        this.MinDamage = minDamage*=(int)this.RarityLevel;
        this.MaxDamage = maxDamage*=(int)this.RarityLevel;
        this.socketNumber = socketNumber;
        this.Gems = new Gem[this.socketNumber];
    }
    private int minDamage;

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int MinDamage
    {
        get
        {
            return minDamage;
        }
        set
        {
            minDamage = value;
        }
    }


    private int maxDamage;

    public int MaxDamage
    {
        get
        {
            return maxDamage;
        }
        set
        {
            maxDamage = value;
        }
    }

    private Gem[] gems;

    public IReadOnlyList<Gem> Gems
    {
        get
        {
            return (IReadOnlyList<Gem>)gems;
        }
        set
        {
            gems = (Gem[])value;
        }
    }

    public RarityLevel RarityLevel { get; protected set; }

    public int strength => this.Gems.Where(g=>g!=null).Select(g => g.Strength).Sum();
    public int agility => this.Gems.Where(g=>g!=null).Select(g => g.Agility).Sum();
    public int vitality => this.Gems.Where(g=>g!=null).Select(g => g.Vitality).Sum();

    private int incresedMinDamage => this.MinDamage + 2 * this.strength + this.agility;

        private int increasedMaxDamage => this.MaxDamage + 3 * this.strength + this.agility * 4;
    protected int socketNumber;

    public void AddGem(Gem gem,int index)
    {
        IndexValidation(index);

        this.gems[index]=gem;
    }
    public void RemoveGem(int index)
    {
        IndexValidation(index);
        if (this.gems[index] == null)
        {
            throw new ArgumentException($"There is no gem here!");
        }

        this.gems[index] = null;
    }

    private void IndexValidation(int index)
    {
        if (index < 0 || index >= this.Gems.Count)
        {
            throw new InvalidOperationException($"Index is not in the array");
        }
    }

    public override string ToString()
    {

        return $"{this.Name}: {this.incresedMinDamage}-{this.increasedMaxDamage} Damage, +{this.strength} Strength, +{this.agility} Agility, +{this.vitality} Vitality";
    }
}
//Ruby(+7 strength, +2 agility, +5 vitality) 
//Axe of Misfortune: 24-46 Damage, +8 Strength, +3 Agility, +6 Vitality