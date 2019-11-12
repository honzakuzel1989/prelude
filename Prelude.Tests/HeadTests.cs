using NUnit.Framework;

namespace System.Prelude.Test
{
    public class HeadTests
    {
        [Test]
        public void HeadTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Assert.That(xs.Head(), Is.EqualTo(1));
        }
    }
}