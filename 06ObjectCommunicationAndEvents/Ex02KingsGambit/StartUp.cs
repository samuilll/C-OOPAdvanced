using Ex02KingsGambit.Factories;
using System;

namespace Ex02KingsGambit
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            IFigureFactory factory = new IFigureFactory();

            Engine engine = new Engine(repo,factory);

            engine.Run();

        }
    }
}
