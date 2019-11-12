using NUnit.Framework;

namespace System.Prelude.Test
{
    public class DropWhileTests
    {
        [Test]
        public void DropWhileTrueTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.DropWhile(_ => true), Is.EqualTo(new int[]{}));
        }

        [Test]
        public void DropWhileFalsTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.DropWhile(_ => false), Is.EqualTo(xs));
        }

        [Test]
        public void DropWhileLessThenFiveTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.DropWhile(x => x < 5), Is.EqualTo(new int[]{5}));
        }
        
        [Test]
        public void DropWhileLessThenZeroTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.DropWhile(x => x == 0), Is.EqualTo(xs));
        }

        [Test]
        public void DropWhileIsOneZeroTest()
        {
            var xs = new string("1111000111");
            Assert.That(string.Join(string.Empty, xs.DropWhile(c => c == '1')), Is.EqualTo("000111"));
        }
    }
}