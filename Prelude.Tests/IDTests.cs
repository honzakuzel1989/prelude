using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class IDTests
    {
        [Test]
        public void IDArrayTest()
        {
            var xs = new bool[]{true, false};
            Assert.That(xs.ID(), Is.EqualTo(xs));
        }

        [Test]
        public void IDNumberTest()
        {
            Assert.That(12.ID(), Is.EqualTo(12));
        }

        [Test]
        public void IDMapTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(xs.Map(Prelude.ID), Is.EqualTo(xs));
        }
    }
}