using NUnit.Framework;

namespace System.Prelude.Test
{
    public class ConcatMapTests
    {
        [Test]
        public void ConcatMapTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.ConcatMap(x => new []{System.Math.Abs(x)}), Is.EqualTo(new int[]{1, 2, 3, 4, 5}));
        }
    }
}