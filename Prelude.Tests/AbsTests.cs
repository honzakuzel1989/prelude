using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class AbsTests
    {
        [Test]
        public void AbsPositiveIntTest()
        {
            Assert.That(22.Abs(), Is.EqualTo(22));
        }

        [Test]
        public void AbsNegativeIntTest()
        {
            Assert.That((-22).Abs(), Is.EqualTo(22));
        }

        [Test]
        public void AbsPositiveRealTest()
        {
            Assert.That(22.0.Abs(), Is.EqualTo(22));
        }

        [Test]
        public void AbsNegativeRealTest()
        {
            Assert.That((-22.0).Abs(), Is.EqualTo(22));
        }
    }
}