using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class TailTests
    {
        [Test]
        public void TailTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Tail(), Is.EqualTo(new int[]{-2, 3, -4, 5}));
        }

        [Test]
        public void TailEmptyListTest()
        {
            var xs = new int[]{};
            Assert.That(() => xs.Tail().Length(), Throws.InstanceOf<PreludeException>());
        }
    }
}