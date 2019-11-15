using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class UntilTests
    {
        [Test]
        public void UntilTest()
        {
            Assert.That(1.Until(x => x > 1000, x => x = x * 2), Is.EqualTo(1024));
        }
    }
}