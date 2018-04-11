using System;
using System.Collections.Generic;
using System.Text;


   public class PetFactory
    {

    public Pet CreatePet(string name, int age, string kind)
    {
        return new Pet(name,age,kind);
    }
    }

