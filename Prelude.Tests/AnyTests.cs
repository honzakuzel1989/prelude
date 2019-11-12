using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class AnyTests
    {
        [Test]
        public void AnyTrueTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Any(x => x > 0), Is.True);
        }

        [Test]
        public void AnyFalseTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Any(x => x == 0), Is.False);
        }
    }
}