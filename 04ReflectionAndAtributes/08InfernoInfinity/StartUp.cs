using System;


    class StartUp
    {
        static void Main(string[] args)
        {
        WeaponFactory weaponFactory = new WeaponFactory();
        GemFactory gemFactory = new GemFactory();
        WeaponRepository weaponRepository = new WeaponRepository();
        CommandInterpreter commandInterpreter = new CommandInterpreter(weaponRepository,weaponFactory,gemFactory);
        Engine engine = new Engine(commandInterpreter);
        engine.Run();

    }
}

//Create;Common Axe; Axe of Misfortune
// Add; Axe of Misfortune;0;Chipped Ruby
