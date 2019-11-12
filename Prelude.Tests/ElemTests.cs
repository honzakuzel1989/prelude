using NUnit.Framework;

namespace System.Prelude.Test
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

        [Test]
        public void ElemStringTrueTest()
        {
            var xs = new string[]{"foo", "bar", "baz"};
            Assert.That(xs.Elem("foo"), Is.True);
        }
    }
}