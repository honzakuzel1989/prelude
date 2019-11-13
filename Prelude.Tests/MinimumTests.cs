using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class MinimumTests
    {
        [Test]
        public void MinimumTest()
        {
            Assert.That(new int[]{1, 2, 0, 4, 5}.Minimum(), Is.EqualTo(0));
        }
    }
}