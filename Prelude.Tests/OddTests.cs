using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class OddTests
    {
        [Test]
        public void OddTrueTest()
        {
            Assert.That(1.Odd(), Is.True);
        }

        [Test]
        public void OddFalseTest()
        {
            Assert.That(2.Odd(), Is.False);
        }
    }
}