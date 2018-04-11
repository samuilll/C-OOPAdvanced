using Ex04WorkForce.Controllers;
using Ex04WorkForce.Repositories;
using System;
using System.Linq;

namespace Ex04WorkForce
{
    class StartUp
    {
        static void Main()
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
