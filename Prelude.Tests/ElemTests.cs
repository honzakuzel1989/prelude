using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class ElemTests
    {
        [Test]
        public void ElemTrueTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(3.Elem(xs), Is.True);
        }

        [Test]
        public void ElemFalseTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(6.Elem(xs), Is.False);
        }

        [Test]
        public void ElemStringTrueTest()
        {
            var xs = new string[]{"foo", "bar", "baz"};
            Assert.That("foo".Elem(xs), Is.True);
        }
    }
}