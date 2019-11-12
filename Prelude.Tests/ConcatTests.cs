using NUnit.Framework;

namespace Prelude.Tests
{
    public class ConcatTests
    {
        [Test]
        public void ConcatTest()
        {
            var xs = new int[][]{new int[]{1}, new int[]{-2}, new int[]{3}, new int[]{-4}, new int[]{5}};
            Assert.That(xs.Concat(), Is.EqualTo(new int[]{1, -2, 3, -4, 5}));
        }
    }
}