using BashSoft.Contracts;
using BashSoft.DataStrucures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoftTester
{
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;
        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }
        [Test]
        public void TestEmptyCtorWithinInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(34);
            Assert.AreEqual(this.names.Capacity, 34);
            Assert.AreEqual(this.names.Size, 0);
        }
        [Test]
        public void TestEmptyCtorWithinInitialComparator()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }
        [Test]
        public void TestEmptyCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase,34);
            Assert.AreEqual(this.names.Capacity, 34);
            Assert.AreEqual(this.names.Size, 0);
        }
        [Test]
        public void TestAddInreasesSide()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }
        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.That(()=>this.names.Add(null),Throws.ArgumentNullException);
        }
        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            Assert.AreEqual("Balkan,Georgi,Rosen", this.names.JoinWith(","));
        }
        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 18; i++)
            {
                this.names.Add("Rosen");
            }

            Assert.AreEqual(32, this.names.Capacity);
            Assert.AreEqual(18, this.names.Size);
        }
        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> list = new List<string>() { "Petkan", "Ivaylo" };

            this.names.AddAll(list);

            Assert.AreEqual(2, this.names.Size);
        }
        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.That(()=>this.names.AddAll(null), Throws.ArgumentNullException);
        }
        [Test]
        public void TestAddAllKeepsSorted()
        {
            List<string> list = new List<string>() { "Petkan", "Ivaylo" ,"Aragon"};

            this.names.AddAll(list);

            Assert.AreEqual("Aragon,Ivaylo,Petkan", this.names.JoinWith(","));
        }
        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            List<string> list = new List<string>() { "Petkan", "Ivaylo", "Aragon" };

            this.names.AddAll(list);

            this.names.Remove("Petkan");
            this.names.Remove("Aragon");

            Assert.AreEqual(1, this.names.Size);
        }
        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            List<string> list = new List<string>() { "Petkan", "Ivaylo", "Aragon" };

            this.names.AddAll(list);

            this.names.Remove("Petkan");

            Assert.AreEqual(this.names.Contains("Petkan"), false);
        }
        [Test]
        public void TestRemovingNullThrowsException()
        {
            List<string> list = new List<string>() { "Petkan", "Ivaylo", "Aragon" };

            Assert.That(()=>this.names.Remove(null), Throws.ArgumentNullException);
        }
        [Test]
        public void TestJoinWithNull()
        {
            List<string> list = new List<string>() { "Petkan", "Ivaylo", "Aragon" };

            Assert.That(()=>this.names.JoinWith(null), Throws.ArgumentNullException);
        }
        [Test]
        public void JoinWithShouldReturnAllElementsWithTheJoinerBetweenThem()
        {
            this.names.AddAll(new string[] { "1", "2", "3" });

            Assert.AreEqual("1, 2, 3", this.names.JoinWith(", "), "Elements are not joined correctly");
        }
        }
    }

