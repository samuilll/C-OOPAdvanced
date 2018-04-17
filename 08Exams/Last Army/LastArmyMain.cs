using System;
using System.Collections.Generic;
using System.Text;


   public class LastArmyMain
    {
      public  static void Main()
        {

        var engine = new Engine();

        engine.Run();

        Console.WriteLine(engine.Result.ToString().TrimEnd('\n'));
         
        }
    }
