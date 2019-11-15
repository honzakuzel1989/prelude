using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class CompareTests
    {
        [Test]
        public void CompareEqTest()
        {
            Assert.That('A'.Compare('A'), Is.EqualTo(0));
        }

        [Test]
        public void CompareLtTest()
        {
            Assert.That(1.Compare(33), Is.EqualTo(-1));
        }

        [Test]
        public void CompareGtTest()
        {
            Assert.That(2.Compare(-3), Is.EqualTo(1));
        }
    }
}