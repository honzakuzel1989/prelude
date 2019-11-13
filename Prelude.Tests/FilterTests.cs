using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class FilterTests
    {
        [Test]
        public void FilterEmptyInputTest()
        {
            var xs = new int[]{};
            Assert.That(xs.Filter(x => x == 0), Is.EqualTo(xs));
        }

        [Test]
        public void FilterEmptyOutputTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Filter(x => x == 0), Is.EqualTo(new int[]{}));
        }

        [Test]
        public void FilterTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Filter(x => x < 0), Is.EqualTo(new int[]{-2, -4}));
        }
    }
}