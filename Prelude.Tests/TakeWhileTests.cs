using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class TakeWhileTests
    {
        [Test]
        public void TakeWhileTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.TakeWhile(x => x <= 3), Is.EqualTo(new int[]{1, -2, 3, -4}));
        }

        [Test]
        public void TakeWhileAllTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.TakeWhile(x => x < 10), Is.EqualTo(xs));
        }

        [Test]
        public void TakeWhileFromEmptyListTest()
        {
            var xs = new int[]{};
            Assert.That(xs.TakeWhile(x => x == -1), Is.EqualTo(xs));
        }
    }
}