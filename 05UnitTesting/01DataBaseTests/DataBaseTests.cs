using _01DataBase;
using NUnit.Framework;
using System;

namespace _01DataBaseTests
{
    [TestFixture]
    public class DataBaseTests
    {
        private DataBase<int> database;

        private int numberToAdd = 12;

        [SetUp]
        public void TestUnit()
        {
            this.database = new DataBase<int>(12, 23, 45, 34, 23, 23, 23, 23, 2, 32, 3, 2, 32, 3, 12, 23);
        }
        [Test]
        public void AddMethodThrowsAnExeptionWhenDataBaseIsFull()
        {

            Assert.That(() => database.AddItem(numberToAdd), Throws.InvalidOperationException.With.Message.EqualTo("There are no more free cells!"));
        }
        [Test]
        public void AssureThatDatabaseCountIncreasesAfterAddMethod()
        {
            database.RemoveItem();
            int initialCount = database.Count;
            database.AddItem(numberToAdd);
            Assert.AreEqual(database.Count, initialCount + 1, "Count does not increase!");
        }
        [Test]
        public void AssureThatDatabaseCountDeccreasesAfterRemoveMethod()
        {
            int initialCount = database.Count;
            database.RemoveItem();
            Assert.AreEqual(database.Count, initialCount - 1, "Count does not increase!");
        }
        [Test]
        public void ThrowAnExeptionWhenRemoveFromEmtyDataBase()
        {
            database = new DataBase<int>();

            Assert.That(() => database.RemoveItem(), Throws.InvalidOperationException.With.Message.EqualTo("There are no  elements in the array"));
        }
        [Test]
        public void ThrowsInvalidOperationExeptionIfTheArraySizeIsNot16()
        {
            int[] testCollection = new int[17];

            Assert.That(() => this.database = new DataBase<int>(testCollection), Throws.InvalidOperationException);
        }

        [Test]
        public void FetchMethodReturnTheRealCountOfTheArrayAfterAdd()
        {
            database = new DataBase<int>(5, 6, 7);

            database.AddItem(15);

            int actualCount = database.Fetch().Split(", ").Length;
            int expectedCount = 4;

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public void FetchMethodReturnTheRealCountOfTheArrayAfterRemove()
        {
            database = new DataBase<int>(5, 6, 7);

            database.RemoveItem();

            int actualCount = database.Fetch().Split(", ").Length;
            int expectedCount = 2;

            Assert.AreEqual(actualCount, expectedCount);
        }
    }
}

