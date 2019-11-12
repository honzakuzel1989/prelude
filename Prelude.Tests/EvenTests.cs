using NUnit.Framework;

namespace System.Prelude.Test
{
    public class EvenTests
    {
        [Test]
        public void EvenFalseTest()
        {
            Assert.That(1.Even(), Is.False);
        }

        [Test]
        public void EvenTrueTest()
        {
            Assert.That(2.Even(), Is.True);
        }
    }
}