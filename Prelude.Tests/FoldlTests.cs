using NUnit.Framework;

namespace Prelude.Tests
{
    public class FoldlTests
    {
        [Test]
        public void FoldlSumTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(xs.Foldl((a, b) => a + b, 0), Is.EqualTo(15));
        }

        [Test]
        public void FoldlConcatTest()
        {
            var xs = new string("string");
            Assert.That(xs.Foldl((a, b) => a.Insert(0, b.ToString()), string.Empty), Is.EqualTo("gnirts"));
        }

        [Test]
        public void FoldlEmptyInputTest()
        {
            var xs = new int[]{};
            Assert.That(xs.Foldl((a, b) => a + b, 0), Is.EqualTo(0));
        }
    }
}