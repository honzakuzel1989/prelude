using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ZipWithTests
    {
        [Test]
        public void ZipWithTest()
        {
            var axs = new int[]{1, 2, 3, 4, 5};
            var bxs = new int[]{6, 7, 8, 9, 10};

            Assert.That(axs.ZipWith(bxs, (a, b) => a + b), Is.EqualTo(new int[]{7, 9, 11, 13, 15}));
        }
    }
}