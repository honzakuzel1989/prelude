using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class NotElemTests
    {
        [Test]
        public void NotElemFalseTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(3.NotElem(xs), Is.False);
        }

        [Test]
        public void NotElemTrueTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(22.NotElem(xs), Is.True);
        }

        [Test]
        public void NotElemEmptyListTest()
        {
            var xs = new int[]{};
            Assert.That(0.NotElem(xs), Is.True);
        }
    }
}