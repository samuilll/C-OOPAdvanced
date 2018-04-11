using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
    public class DummyTests
    {
        private Dummy dummy;
        private int health = 10;
        private int experience = 10;

        [SetUp]
        public void TestUnit()
        {
            this.dummy = new Dummy(health,experience);
        }
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            int attackPoints = 5;

            this.dummy.TakeAttack(attackPoints);

            Assert.AreEqual(health - attackPoints, this.dummy.Health, "Health does not decrease under attack!");
        }
        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            int attackPoints = 15;

            dummy.TakeAttack(attackPoints);

            Assert.That(()=>dummy.TakeAttack(attackPoints),Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            int attackPoints = this.dummy.Health;

            this.dummy.TakeAttack(attackPoints);

            Assert.AreEqual(this.experience,this.dummy.GiveExperience(),"Dead dummy does not give experience!");
        }
        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.That(()=>this.dummy.GiveExperience(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
        }

    }
}
