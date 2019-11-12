using System.Linq;
using NUnit.Framework;

namespace Prelude.Tests
{
    public class IterateTests
    {
        [Test]
        public void IterateTest()
        {
            var xs = new bool[]{true, false};
            Assert.That(1.Iterate(x => x + 1).Take(10), Is.EqualTo(Enumerable.Range(1, 10)));
        }
    }
}