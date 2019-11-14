using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class SplitAtTests
    {
        [Test]
        public void SplitAtTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Assert.That(xs.SplitAt(5), Is.EqualTo((new int[]{1, 2, 3, 4, 5}, new int[]{6, 7, 8, 9, 10})));
        }

        [Test]
        public void SplitAtEmptyArrayTest()
        {
            var xs = new int[]{};
            Assert.That(xs.SplitAt(5), Is.EqualTo((new int[]{}, new int[]{})));
        }

        [Test]
        public void SplitAtZeroTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(xs.SplitAt(0), Is.EqualTo((new int[]{}, xs)));
        }

        [Test]
        public void SplitAtNegativeNumberTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(() => xs.SplitAt(-6), Throws.InstanceOf<PreludeException>());
        }
    }
}