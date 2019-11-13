using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class NotTests
    {
        [Test]
        public void NotTrueTest()
        {
            Assert.That(true.Not(), Is.False);
        }

        [Test]
        public void NotFalseTest()
        {
            Assert.That(false.Not(), Is.True);
        }
    }
}