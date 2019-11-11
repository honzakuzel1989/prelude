using NUnit.Framework;

namespace Prelude.Tests
{
    public class AndTests
    {
        [Test]
        public void AndFalseTest()
        {
            var xs = new bool[]{true, false};
            Assert.That(xs.And(), Is.False);
        }

        [Test]
        public void AndTrueTest()
        {
            var xs = new bool[]{true};
            Assert.That(xs.And(), Is.True);
        }
    }
}