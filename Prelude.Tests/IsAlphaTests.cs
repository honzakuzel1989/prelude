using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class IsAlphaTests
    {
        [Test]
        public void IsAlphaLowerTest()
        {
            Assert.That('a'.IsAlpha(), Is.True);
        }

        [Test]
        public void IsAlphaUpperTest()
        {
            Assert.That('C'.IsAlpha(), Is.True);
        }

        [Test]
        public void IsAlphaFalseTest()
        {
            Assert.That('1'.IsAlpha(), Is.False);
        }
    }
}