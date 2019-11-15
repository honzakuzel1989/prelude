using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ZipTests
    {
        [Test]
        public void ZipSecondShorterTest()
        {
            var axs = new int[]{1, 2, 3, 4, 5};
            var bxs = new char[]{'a', 'b', 'c'};
            Assert.That(axs.Zip(bxs), Is.EqualTo(new []{(1, 'a'), (2, 'b'), (3, 'c')}));
        }

        [Test]
        public void ZipFirstShorterTest()
        {
            var axs = new int[]{1};
            var bxs = new char[]{'a', 'b', 'c'};
            Assert.That(bxs.Zip(axs), Is.EqualTo(new []{('a', 1)}));
        }
    }
}