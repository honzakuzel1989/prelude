using NUnit.Framework;

namespace System.Prelude.Test
{
    public class Foldr1Tests
    {
        [Test]
        public void Foldr1MultTrueTest()
        {
            var xs = new int[]{5, 4, 3, 2, 1};
            Assert.That(xs.Foldr1((x, b) => x * b), Is.EqualTo(120));
        }
    }
}