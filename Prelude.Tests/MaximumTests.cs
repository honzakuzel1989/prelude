using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class MaximumTests
    {
        [Test]
        public void MaximumTest()
        {
            Assert.That(new int[]{1, 21, 0, 4, 5}.Maximum(), Is.EqualTo(21));
        }
    }
}