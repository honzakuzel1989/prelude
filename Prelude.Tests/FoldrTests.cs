using NUnit.Framework;

namespace System.Prelude.Test
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

        [Test]
        public void FoldrEmptyInputTest()
        {
            var xs = new bool[]{};
            Assert.That(xs.Foldr((x, b) => x || b, true), Is.True);
        }
    }
}