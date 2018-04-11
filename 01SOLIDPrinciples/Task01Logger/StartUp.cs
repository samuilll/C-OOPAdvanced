using System;
using System.Collections.Generic;
using System.Globalization;
using Task01Logger.Entities;
using Task01Logger.Factories;
using Task01Logger.Interfaces;

namespace Task01Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();

            Engine engine = new Engine(logger);

            engine.Run();
        }
    }
}
