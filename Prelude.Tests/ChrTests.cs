using NUnit.Framework;

namespace System.Prelude.Test
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