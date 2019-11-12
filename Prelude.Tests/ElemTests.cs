using NUnit.Framework;

namespace Prelude.Tests
{
    public class ElemTests
    {
        [Test]
        public void ElemTrueTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Elem(3), Is.True);
        }

        [Test]
        public void ElemFalseTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Elem(6), Is.False);
        }
    }
}