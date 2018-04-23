using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

  public  class LastArmyMain
    {
        static void Main()
        {
        IServiceProvider serviceProvider = ConfigureServices();
        IWriter writer = serviceProvider.GetService<IWriter>();
        IReader reader = serviceProvider.GetService<IReader>();
        GameController gameController = new GameController(serviceProvider);
        Engine engine = new Engine(gameController,writer,reader);
        engine.Run();
        }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<MissionController>();
        services.AddSingleton<IArmy, Army>();
        services.AddSingleton<IWriter, ConsoleWriter>();
        services.AddSingleton<IReader, ConsoleReader>();
        services.AddSingleton<IWareHouse, WareHouse>();
        services.AddTransient<IMissionFactory, MissionFactory>();
        services.AddTransient<ISoldierFactory, SoldierFactory>();
        services.AddTransient<IAmmunitionFactory, AmmunitionFactory>();



        IServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}
