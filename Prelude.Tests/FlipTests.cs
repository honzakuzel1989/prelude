using System;
using NUnit.Framework;

namespace Prelude.Tests
{
    public class FlipTests
    {
        [Test]
        public void FlipTest()
        {
            var xs = new int[]{1, -2, 3, -4, 5};
            Func<int, int[], bool> f = (int i, int[] l) => l.Length == i;
            Assert.That(Prelude.Flip<int, int[], bool>(f, xs, 5), Is.True);
        }
    }
}