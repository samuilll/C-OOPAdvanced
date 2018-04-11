using _01DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01DataBaseTests
{
    [TestFixture]
  public  class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        private  Person difernetPersonForManipulating = new Person(300, "Gominko");

        private  Person existingPersonNameForManipulating = new Person(201, "Gonko");

        private Person existingPersonIDForManipulating = new Person(122, "Beni");


        [SetUp]
        public void UnitTest()
        {
            this.database = new ExtendedDatabase(new Person(122, "Vanio"), new Person(3, "Gonko"));
        }
        [Test]
        public void ThrowAnExeptionWhenAddPersonWithexistingUsername()
        {
            Assert.That(()=>database.AddItem(this.existingPersonNameForManipulating),
                Throws.InvalidOperationException
                .With.Message.EqualTo("You already have a person with the same username"));
        }
        [Test]
        public void ThrowAnExeptionWhenAddPersonWithexistingID()
        {
            Assert.That(() => database.AddItem(this.existingPersonIDForManipulating),
               Throws.InvalidOperationException
               .With.Message.EqualTo("You already have a person with the same id"));
        }
        [Test]
        public void ThrowAnExeptionWhenSearchUserWithNonexistingUserName()
        {
            string nonExisistingName = "Minko";
            Assert.That(() => database.FindByUseName(nonExisistingName),
              Throws.InvalidOperationException
              .With.Message.EqualTo("There is no person with the given username"));
        }
        [Test]
        public void ThrowAnExeptionWhenSearchUserWithUnexistingID()
        {
            int nonExisistingId = 2345;
            Assert.That(() => database.FindById(nonExisistingId),
              Throws.InvalidOperationException
              .With.Message.EqualTo("There is no person with the given id"));
        }
        [Test]
        public void ThrowAnExeptionWhenSearchByUserNameWithNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUseName(null));

        }
        [Test]
        public void ThrowAnExeptionWhenSearchByIDWithNegativeParameter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));

        }

    }
}
