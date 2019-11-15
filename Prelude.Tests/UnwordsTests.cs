using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class UnwordsTests
    {
        [Test]
        public void UnwordsTest()
        {
            var xs = new string[]{"the", "quick", "brown", "fox"};
            Assert.That(xs.Unwords(), Is.EqualTo("the quick brown fox"));
        }
    }
}