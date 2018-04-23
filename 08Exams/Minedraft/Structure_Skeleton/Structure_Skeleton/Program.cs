using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        //IEnergyRepository energyRepository = new EnergyRepository();
        //IHarvesterController harvesterController = new HarvesterController(energyRepository);
        //IProviderController providerController = new ProviderController(energyRepository);
        IServiceProvider serviceProvider = ConfigureServices();
        ICommandInterpreter interpreter = new CommandInterpreter(serviceProvider);
        IReader reader = new Reader();
        IWriter writer = new Writer();
        StringBuilder builder = new StringBuilder();

        Engine engine = new Engine(reader,writer,builder,interpreter);

        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IHarvesterController, HarvesterController>();
        services.AddSingleton<IProviderController, ProviderController>();
        services.AddSingleton<IEnergyRepository, EnergyRepository>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}