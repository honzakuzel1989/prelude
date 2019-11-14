using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ReverseTests
    {
        [Test]
        public void ReverseTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(xs.Reverse(), Is.EqualTo(new int[]{5, 4, 3, 2, 1}));
        }

        [Test]
        public void ReverseEmptyListTest()
        {
            var xs = new int[]{};
            Assert.That(xs.Reverse(), Is.EqualTo(new int[]{}));
        }
    }
}