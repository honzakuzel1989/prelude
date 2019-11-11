using NUnit.Framework;

namespace Prelude.Tests
{
    public class FoldrTests
    {
        [Test]
        public void FoldrAllTrueTest()
        {
            var xs = new bool[]{true, false};
            Assert.That(xs.Foldr((x, b) => x && b, true), Is.False);
        }

        [Test]
        public void FoldrAnyTrueTest()
        {
            var xs = new bool[]{true, false};
            Assert.That(xs.Foldr((x, b) => x || b, true), Is.True);
        }
    }
}