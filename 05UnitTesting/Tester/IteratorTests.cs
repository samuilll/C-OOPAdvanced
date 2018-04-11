using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
    [TestFixture]
   public class IteratorTests
    {
        private ListIterator list;
        [SetUp]
        public void UnitTest()
        {
            this.list = new ListIterator(new List<string>(){ "Petko","Gosho"});
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenParameterIsNull()
        {
            Assert.That(()=>new ListIterator(null),Throws.ArgumentNullException);
        }
        [Test]
        public void MoveMethodReturnsTrueWhenSuccessful()
        {
            Assert.AreEqual(true, list.Move());
        }
        [Test]
        public void MoveMethodReturnsFalseWhenNotSuccessful()
        {
            list.Move();
            list.Move();
            Assert.AreEqual(false, list.Move());
        }
        [Test]
        public void HasNextMethodReturnsTrueWhenSuccessful()
        {
            Assert.AreEqual(true, list.HasNext());
        }
        [Test]
        public void HasNextMethodReturnsFalseWhenNotSuccessful()
        {
            list.Move();
            Assert.AreEqual(false, list.HasNext());
        }

    }
}
