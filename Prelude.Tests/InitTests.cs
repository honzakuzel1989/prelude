using NUnit.Framework;

namespace System.Prelude.Test
{
    public class InitTests
    {
        [Test]
        public void InitBoolArrayTest()
        {
            var xs = new bool[]{true, false};
            Assert.That(xs.Init(), Is.EqualTo(new bool[]{ true }));
        }

        [Test]
        public void IDNumberTest()
        {
            Assert.That(() => new int[]{}.Init(), Throws.InstanceOf<PreludeException>());
        }

        [Test]
        public void InitIntArrayTest()
        {
            var xs = new int[]{1, 2, 3, 4, 5};
            Assert.That(xs.Init(), Is.EqualTo(new int[]{ 1, 2, 3, 4 }));
        }
    }
}