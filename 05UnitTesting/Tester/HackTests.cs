using _07Hack;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
  public  class HackTests
    {
        [Test]
        public void ReturnsRightAbsValue()
        {
            var fakeAbs = new Mock<IAbs>();

            var actualValue = fakeAbs.Object.Absolute(-234);

            var expectedValue = 234;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
