using NUnit.Framework;

namespace System.Prelude.Tests
{
    // http://zvon.org/other/haskell/Outputprelude/index.html
    public class RemTests
    {
        [Test]
        public void RemPostiveResult1Test()
        {
            Assert.That(33.Rem(12), Is.EqualTo(9));
        }

        [Test]
        public void RemNegativeResult1Test()
        {
            Assert.That((-33).Rem(12), Is.EqualTo(-9));
        }

        [Test]
        public void RemNegativeResult2Test()
        {
            Assert.That((-33).Rem(-12), Is.EqualTo(-9));
        }

        [Test]
        public void RemPositiveResult2Test()
        {
            Assert.That((33).Rem(-12), Is.EqualTo(9));
        }
    }
}