using NUnit.Framework;

namespace System.Prelude.Test
{
    public class LCDTests
    {
        [Test]
        public void LCMTwoAndTenTest()
        {
            Assert.That(2.LCM(10), Is.EqualTo(10));
        }

        [Test]
        public void LCMTwoAndElevenTest()
        {
            Assert.That(2.LCM(11), Is.EqualTo(22));
        }

        [Test]
        public void LCMArrayTest()
        {
            var xxs = new int []{2, 3, 4, 5, 6, 7, 8, 9, 10};
            Assert.That(xxs.Foldr1(Prelude.LCM), Is.EqualTo(2520));
        }
    }
}