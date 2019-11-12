using NUnit.Framework;

namespace Prelude.Tests
{
    public class DigitToIntTests
    {
        [Test]
        public void Digit5ToIntTest()
        {
            Assert.That('5'.DigitToInt(), Is.EqualTo(5));
        }

        [Test]
        public void DigitFToIntTest()
        {
            Assert.That('F'.DigitToInt(), Is.EqualTo(15));
        }

        [Test]
        public void DigitIsNotDigitToIntTest()
        {
            Assert.That(() => '*'.DigitToInt(), Throws.InstanceOf<PreludeException>());
        }
    }
}