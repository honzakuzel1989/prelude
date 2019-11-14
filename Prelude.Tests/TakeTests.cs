using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class TakeTests
    {
        [Test]
        public void TakeZeroTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Take(0), Is.EqualTo(new int[]{}));
        }

        [Test]
        public void TakeMoreThenLengthTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Take(10), Is.EqualTo(xs));
        }

        [Test]
        public void TakeMinusThrowsTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(() => xs.Take(-1), Throws.InstanceOf<PreludeException>());
        }

        [Test]
        public void TakeTwoTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Take(2), Is.EqualTo(new int[]{1, -2}));
        }
    }
}