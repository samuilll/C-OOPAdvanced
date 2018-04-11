using System;
using System.Collections.Generic;
using System.Text;


  public  class Pet:IComparable<Pet>
    {

    public Pet(string name, int age, string type)
    {
        this.Name = name;
        this.Age = age;
        this.Type = type;
    }

    private string name;

    public string Name
    {
        get { return name; }
       private set { name = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
       private set { age = value; }
    }

    private string type;  
    public string Type
    {
        get { return type; }
       private set { type = value; }
    }

    public int CompareTo(Pet other)
    {
        return this.Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Type}";
    }
}

