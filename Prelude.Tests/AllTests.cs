using NUnit.Framework;

namespace Prelude.Tests
{
    public class AllTests
    {
        [Test]
        public void AllFalseTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.All(x => x > 0), Is.False);
        }

        [Test]
        public void AllTrueTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.All(x => x != 0), Is.True);
        }
    }
}