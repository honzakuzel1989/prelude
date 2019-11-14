using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class UnlineTests
    {
        [Test]
        public void UnlineTest()
        {
            var xs = new string[]{"Hello", "World", "from", "Prelude"};
            Assert.That(xs.Unlines(), Is.EqualTo("Hello\nWorld\nfrom\nPrelude\n"));
        }

        [Test]
        public void UnlineEmptyListTest()
        {
            var xs = new string[]{};
            Assert.That(xs.Unlines(), Is.EqualTo(xs));
        }
    }
}