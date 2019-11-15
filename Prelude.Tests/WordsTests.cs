using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class WordsTests
    {
        [Test]
        public void WordsTest()
        {
            var xs = "the quick brown\n\nfox";
            Assert.That(xs.Words(), Is.EqualTo(new string[]{"the", "quick", "brown", "fox"}));
        }
    }
}