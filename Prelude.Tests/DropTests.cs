using NUnit.Framework;

namespace Prelude.Tests
{
    public class DropTests
    {
        [Test]
        public void Drop0Test()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Drop(0), Is.EqualTo(xs));
        }

        [Test]
        public void DropLessThanLenghtTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Drop(3), Is.EqualTo(new int[]{-4, 5}));
        }

        [Test]
        public void DropMoreThanLenghtTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Drop(6), Is.EqualTo(new int[]{}));
        }

        [Test]
        public void DropExceptionThanLenghtTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(() => xs.Drop(-10), Throws.InstanceOf<PreludeException>());
        }
    }
}