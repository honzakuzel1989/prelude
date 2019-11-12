using NUnit.Framework;

namespace Prelude.Tests
{
    public class Foldl1Tests
    {
        [Test]
        public void Foldl1SumTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(xs.Foldl1((a, b) => a + b), Is.EqualTo(15));
        }

        [Test]
        public void Foldl1MaxTest()
        {
            var xs = new string("string");
            Assert.That(xs.Foldl1((a, b) => a > b ? a : b), Is.EqualTo('t'));
        }

        [Test]
        public void Foldl1MultTrueTest()
        {
            var xs = new int[]{5, 4, 3, 2, 1};
            Assert.That(xs.Foldl1((x, b) => x * b), Is.EqualTo(120));
        }
    }
}