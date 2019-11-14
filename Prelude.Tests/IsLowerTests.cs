using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class IsLowerTests
    {
        [Test]
        public void IsLowerTrueTest()
        {
            Assert.That('j'.IsLower(), Is.True);
        }

        [Test]
        public void IsLowerFalseTest()
        {
            Assert.That('K'.IsLower(), Is.False);
        }
    }
}