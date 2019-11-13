using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class LengthTests
    {
        [Test]
        public void LengthEmptyArrayTest()
        {
            var xs = new int[]{};
            Assert.That(xs.Length(), Is.EqualTo(0));
        }

        [Test]
        public void LengthTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Length(), Is.EqualTo(5));
        }
    }
}