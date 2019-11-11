using NUnit.Framework;

namespace Prelude.Tests
{
    public class ChrTests
    {
        [Test]
        public void ChrTest()
        {
            Assert.That(65.Chr(), Is.EqualTo('A'));
        }
    }
}