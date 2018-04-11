using System;
using System.Collections.Generic;
using System.Text;

namespace _01DataBase
{
    public class Person : IEqualityComparer<Person>
    {
        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public long Id { get;private set; }
        public string UserName { get;private set; }
        public bool Equals(Person x, Person y)
        {
            return x.Id == y.Id && x.UserName == y.UserName;
        }

        public int GetHashCode(Person obj)
        {
            return $"{obj.Id}{obj.UserName}".GetHashCode();
        }
    }
}
