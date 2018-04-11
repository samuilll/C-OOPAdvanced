using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01DataBase
{
    public class ExtendedDatabase : DataBase<Person>
    { 


        public ExtendedDatabase(params Person[] people) : base(people)
        {
        }

        public Person FindById(long id)
        {
            if (id<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Person person = this.array.Take(Count).FirstOrDefault(p => p.Id == id);

            if (person==null)
            {
                throw new InvalidOperationException("There is no person with the given id");
            }

            return person;
        }
        public Person FindByUseName(string name)
        {
            if (name==null)
            {
                throw new ArgumentNullException();
            }
            Person person = this.array.Take(Count).FirstOrDefault(p => p.UserName == name);

            if (person == null)
            {
                throw new InvalidOperationException("There is no person with the given username");
            }

            return person;
        }

        public override void AddItem(Person person)
        {
            if (this.currentIndex>0)
            {
                if (this.array.Take(Count).Any(p => p.UserName == person.UserName))
                {
                    throw new InvalidOperationException("You already have a person with the same username");
                }
                if (this.array.Take(Count).Any(p => p.Id == person.Id))
                {
                    throw new InvalidOperationException("You already have a person with the same id");
                }

            }
            this[currentIndex]=person;

            this.currentIndex++;
        }

    }
}
