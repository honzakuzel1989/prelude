using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class MaxTests
    {
        [Test]
        public void MaxXTest()
        {
            Assert.That(6.Max(1), Is.EqualTo(6));
        }

        [Test]
        public void MaxYTest()
        {
            Assert.That(1.Max(10), Is.EqualTo(10));
        }

        [Test]
        public void MaxSameTest()
        {
            Assert.That(1.Max(1), Is.EqualTo(1));
        }
    }
}