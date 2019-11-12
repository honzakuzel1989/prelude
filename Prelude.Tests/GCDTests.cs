using NUnit.Framework;

namespace Prelude.Tests
{
    public class GCDTests
    {
        [Test]
        public void GCDTwoAndTenTest()
        {
            Assert.That(2.GCD(10), Is.EqualTo(2));
        }

        [Test]
        public void GCDMinusSevenAndTwoAndTenTest()
        {
            Assert.That(13.GCD(-7), Is.EqualTo(1));
        }

        [Test]
        public void GCDExceptioTest()
        {
            Assert.That(() => 0.GCD(0), Throws.InstanceOf<PreludeException>());
        }

        [Test]
        public void GCDTenAndZeroTest()
        {
            Assert.That(10.GCD(0), Is.EqualTo(10));
        }

        [Test]
        public void GCDZeroAndTenTest()
        {
            Assert.That(0.GCD(10), Is.EqualTo(10));
        }

        [Test]
        public void GCDTest()
        {
            Assert.That(Prelude.GCD(54, 24), Is.EqualTo(6));
        }
    }
}