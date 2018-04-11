using Ex02KingsGambit.Commands;
using Ex02KingsGambit.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ex02KingsGambit
{
   public class Engine
    {

        private Repository repo;
        private IFigureFactory factory = new IFigureFactory();
    
        public Engine(Repository repo, IFigureFactory factory)
        {
            this.repo = repo;
            this.factory = factory;
        }

        public void Run()
        {
            CreateAnArmyAndAddToTheReppo();

            while (true)
            {
                string[] args = Console.ReadLine().Split();

                string commandName = args[0];

                if (commandName=="End")
                {
                    break;
                }

                string data = args[1];

                Type commandType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == commandName + "Command");

                IExecutable command = (IExecutable)Activator.CreateInstance(commandType,new object[] { this.repo});

                command.Execute(data);
            }

        }

        private void CreateAnArmyAndAddToTheReppo()
        {
            string kingName = Console.ReadLine();

            CreateFigureAndAddToTheRepo("King", kingName);

            foreach (var figureName in Console.ReadLine().Split())
            {
                CreateFigureAndAddToTheRepo("RoyalGuard", figureName);
            }

            foreach (var figureName in Console.ReadLine().Split())
            {
                CreateFigureAndAddToTheRepo("Footman", figureName);
            }
        }

        private void CreateFigureAndAddToTheRepo(string typeName,string figureName)
        {
            this.repo.AddFigure(factory.CreateFigure(typeName, figureName));
        }
       

    }
}
