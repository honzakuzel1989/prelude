using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class IsUpperTests
    {
        [Test]
        public void IsUpperTrueTest()
        {
            Assert.That('J'.IsUpper(), Is.True);
        }

        [Test]
        public void IsUpperFalseTest()
        {
            Assert.That('k'.IsUpper(), Is.False);
        }
    }
}