using NUnit.Framework;

namespace System.Prelude.Tests
{
    // http://zvon.org/other/haskell/Outputprelude/mod_f.html
    public class ModTests
    {
        [Test]
        public void ModPostiveResultTest()
        {
            Assert.That(3.Mod(12), Is.EqualTo(3));
        }

        [Test]
        public void ModNegativeDividentResultTest()
        {
            Assert.That(33.Mod(-12), Is.EqualTo(-3));
        }

        [Test]
        public void ModNegativeDivisorResultTest()
        {
            Assert.That((-33).Mod(12), Is.EqualTo(-9));
        }

        [Test]
        public void ModNegativeResultTest()
        {
            Assert.That((-33).Mod(-12), Is.EqualTo(3));
        }
    }
}