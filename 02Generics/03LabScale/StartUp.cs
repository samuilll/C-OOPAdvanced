using System;


   public class StartUp
    {
      public  static void Main()
        {
        Scale<string> scale = new Scale<string>("EFI", "EFI");

        Console.WriteLine(scale.GetHeavier());
        }
    }

