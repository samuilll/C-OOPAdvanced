using Ex02KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Entities
{
    public abstract class Figure : IFigure
    {
        protected Figure(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual string AttackReaction { get; }


        public void Respond()
        {
            Type type = this.GetType();

            string typeAsString = type.Name;
            if (typeAsString=="RoyalGuard")
            {
                typeAsString = "Royal Guard";
            }
            Console.WriteLine($"{typeAsString} {this.Name} {this.AttackReaction}!");

        }
    }
}
