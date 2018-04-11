using System;
using System.Collections.Generic;
using System.Text;


   public class Person:IComparable<Person>
    {

    private string name;
    private int age;


    public string Name { get { return this.name; } }
    
    public int Age { get { return this.age; } }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age); 
        }

        return result;
    }
    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return this.Age.CompareTo(other.Age) == 0;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return $"{this.Name} {this.Age}".GetHashCode();
    }
}

