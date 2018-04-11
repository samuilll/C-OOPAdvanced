using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


  public  class GemFactory
    {

    public Gem CreateGem(string clarityAsString,string gemType)
    {
        if (!Enum.TryParse<Clarity>(clarityAsString,out Clarity clarity))
        {
            throw new ArgumentException("Invalid clarity value!");
        }

        Type typeOfGem = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t=>t.Name==gemType);

        if (typeOfGem==null)
        {
            throw new ArgumentException("Invalid type of a gem!");

        }

        Gem gem = (Gem)Activator.CreateInstance(typeOfGem,new object[] { clarity});

        return gem;
    }
    }

