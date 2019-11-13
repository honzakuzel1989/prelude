using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class NullTests
    {
        [Test]
        public void NullTrueTest()
        {
            var xs = new string(string.Empty);
            Assert.That(xs.Null, Is.True);
        }

        [Test]
        public void NullFalseTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(xs.Null(), Is.False);
        }
    }
}