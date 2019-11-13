using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class MinTests
    {
        [Test]
        public void MinYTest()
        {
            Assert.That(6.Min(1), Is.EqualTo(1));
        }

        [Test]
        public void MinXTest()
        {
            Assert.That(1.Min(10), Is.EqualTo(1));
        }

        [Test]
        public void MinSameTest()
        {
            Assert.That(1.Min(1), Is.EqualTo(1));
        }
    }
}