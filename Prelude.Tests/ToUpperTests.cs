using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ToUpperTests
    {
        [Test]
        public void ToUpperLowercaseTest()
        {
            Assert.That('c'.ToUpper(), Is.EqualTo('C'));
        }

        [Test]
        public void ToUpperUppercaseTest()
        {
            Assert.That('C'.ToUpper(), Is.EqualTo('C'));
        }
    }
}