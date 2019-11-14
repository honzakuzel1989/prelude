using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ToLowerTests
    {
        [Test]
        public void ToLowerLowercaseTest()
        {
            Assert.That('c'.ToLower(), Is.EqualTo('c'));
        }

        [Test]
        public void ToLowerUppercaseTest()
        {
            Assert.That('C'.ToLower(), Is.EqualTo('c'));
        }
    }
}