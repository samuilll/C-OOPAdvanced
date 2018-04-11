using System;
using System.Collections.Generic;
using System.Text;


   public class Room
    {


    private Pet pet;

    public Pet Pet
    {
        get { return pet; }
       private set { pet = value; }
    }

    private bool hasPet = false;

    public bool HasPet
    {
      get { return hasPet; }
      private  set { hasPet = value; }
    }

    public void AddPet(Pet pet)
    {
        this.Pet = pet;

        this.HasPet = true;
    }

    public void ReleasePet()
    {
        this.Pet = null;
        this.HasPet = false;
    }
}

