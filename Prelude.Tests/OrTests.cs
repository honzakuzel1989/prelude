using NUnit.Framework;

namespace System.Prelude.Test
{
    public class OrTests
    {
        [Test]
        public void OrFalseTest()
        {
            var xs = new bool[]{false};
            Assert.That(xs.Or(), Is.False);
        }

        [Test]
        public void OrTrueTest()
        {
            var xs = new bool[]{true, false};
            Assert.That(xs.Or(), Is.True);
        }
    }
}