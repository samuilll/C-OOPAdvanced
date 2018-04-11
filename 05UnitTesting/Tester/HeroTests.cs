using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
    [TestFixture]
  public  class HeroTests
    {
        [Test]
        public void GetXPFromTheDeadTarget()
        {
            var fakeWeapon = new Mock<IWeapon>();
            var fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(ft => ft.GiveExperience()).Returns(10);
            fakeTarget.Setup(ft => ft.IsDead()).Returns(true);

            Hero hero = new Hero("Michelle",fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);
            Assert.AreEqual(fakeTarget.Object.GiveExperience(), hero.Experience,"Cannot get experience from the dead target!");
        }
    }
}
