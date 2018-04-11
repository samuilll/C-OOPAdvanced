public abstract class Gem
{
    protected Gem(int strength, int agility, int vitality,Clarity clarity)
    {
        this.clarity = clarity;
        this.Strength = strength + (int)this.clarity;
        this.Agility = agility+(int)this.clarity;
        this.Vitality = vitality+(int)this.clarity;
    }
    protected Clarity clarity; 
    public int Strength { get;protected set; }

    public int Agility { get; protected set; }

    public int Vitality { get; protected set; }

}

