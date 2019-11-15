using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class DivTests
    {
        [Test]
        public void DivPositiveResultTest()
        {
            Assert.That(16.Div(9), Is.EqualTo(1));
        }

        [Test]
        public void DivNegativeResultTest()
        {
            Assert.That((-12).Div(5), Is.EqualTo(-3));
        }
    }
}