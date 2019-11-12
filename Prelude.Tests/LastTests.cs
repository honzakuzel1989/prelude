using NUnit.Framework;

namespace System.Prelude.Test
{
    public class LastTests
    {
        [Test]
        public void LastTest()
        {
            var xxs = new int []{1, 2, 3, 4};
            Assert.That(xxs.Last(), Is.EqualTo(4));
        }

        [Test]
        public void LastExceptionTest()
        {
            var xxs = new int []{};
            Assert.That(() => xxs.Last(), Throws.InstanceOf<PreludeException>());
        }
    }
}