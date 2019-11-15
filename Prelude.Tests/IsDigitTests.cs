using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class IsDigitTests
    {
        [Test]
        public void IsDigitTrueTest()
        {
            Assert.That('1'.IsDigit(), Is.True);
        }

        [Test]
        public void IsDigitFalseTest()
        {
            Assert.That('K'.IsDigit(), Is.False);
        }
    }
}